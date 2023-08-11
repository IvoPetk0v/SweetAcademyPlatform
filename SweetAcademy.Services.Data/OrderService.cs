using System.Globalization;
using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Order;
using SweetAcademy.Web.ViewModels.Recipe;
using SweetAcademy.Web.ViewModels.Training;
using SweetAcademy.Web.ViewModels.User;
using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly SweetAcademyDbContext dbContext;

        public OrderService(SweetAcademyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAnOrderAsync(RegisterOrderViewModel model, Guid userId)
        {
            if (!dbContext.ApplicationUsers.Any(u => u.Id == userId))
            {
                throw new ArgumentException(message: "User is not found");
            }
            var training = await dbContext.Trainings.Include(t=>t.Orders).FirstOrDefaultAsync(t => t.Id == model.TrainingId && t.Active);

            if (training == null || training.Active == false)
            {
                throw new ArgumentException(
                    message: "Training is no longer active or there is no such a training at all");
            }

            if (training.OpenSeats <= training.Orders.Count)
            {
                throw new OperationCanceledException(
                    message:
                    "Sorry, the training no longer have free slots in the kitchen.You can choose another training or wait for next event.");
            }
            var order = new Order()
            {
                TrainingId = model.TrainingId,
                UserId = model.UserId,
                TotalPrice = model.TotalPrice,
                OrderedTraining = (await dbContext.Trainings.FindAsync(model.TrainingId))!
            };
            await this.dbContext.Orders.AddAsync(order);
            if (training.OpenSeats == training.Orders.Count)
            {
                training.Orders.Add(order);
                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                training.Orders.Add(order);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<RegisterOrderViewModel> LoadOrderInfoAsync(int trainingId, Guid userId)
        {
            var training = await dbContext.Trainings
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .ThenInclude(t => t.Product)
                .Include(t => t.Trainer).FirstOrDefaultAsync(t => t.Id == trainingId && t.Active);
            if (training == null)
            {
                throw new ArgumentException(
                    message: "Training is no longer active or there is no such training at all.");
            }
            var model = new RegisterOrderViewModel()
            {
                OrderedTraining = new TrainingViewModel()
                {
                    Id = training.Id,
                    ChefFullName = training.Trainer.FullName,
                    ChefId = training.ChefId,
                    Name = training.Name,
                    Active = training.Active,
                    OpenSeats = training.OpenSeats,
                    SeatsLeft = training.OpenSeats - training.Orders.Count,
                    Recipe = new ShowRecipeViewModel()
                    {
                        ImageUrl = training.Recipe.ImageUrl,
                    },
                    StartDate = training.StartDate,
                },
                TrainingId = training.Id,
                UserId = userId,
                TotalPrice = decimal.Round((training.Recipe.RecipeProducts
                                  .Sum(rp => rp.Product.Price * (decimal)rp.Quantity) +
                              (decimal)training.Trainer.TaxPerTrainingForStudent) *
                             PlatformInterestForTrainingSession, 2, MidpointRounding.AwayFromZero)
            };

            return model;
        }

        public async Task<ICollection<OrdersUserViewModel>> LoadOrdersListItemsAsync(Guid userId)
        {
            var userOrders = await dbContext.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderedTraining)
                .ThenInclude(o=>o.Recipe)
                .Include(o => o.OrderedTraining.Trainer)
                .Select(o => new OrdersUserViewModel()
                {
                    UserId = o.UserId,
                    Trainings = new TrainingViewModel()
                    {
                        Name = o.OrderedTraining.Name,
                        StartDate = o.OrderedTraining.StartDate,
                        ChefFullName = o.OrderedTraining.Trainer.FullName,
                        Recipe = new ShowRecipeViewModel()
                        {
                            ImageUrl = o.OrderedTraining.Recipe.ImageUrl,
                            Description = o.OrderedTraining.Recipe.Description,
                        }
                    },
                    TotalPrice = (decimal.Round(o.TotalPrice, 2, MidpointRounding.AwayFromZero)).ToString(CultureInfo.InvariantCulture),
                    User = new UserViewModel()
                    {
                        Id = userId,
                        UserName = dbContext.ApplicationUsers.First(u=>u.Id==userId).UserName
                    }
                }).ToArrayAsync();
            return userOrders;
        }
    }
}
