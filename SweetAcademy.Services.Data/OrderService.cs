using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Chef;
using SweetAcademy.Web.ViewModels.Order;
using SweetAcademy.Web.ViewModels.Training;
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

            if (!dbContext.Trainings.Any(t => t.Id == model.TrainingId) || dbContext.Trainings.First(t => t.Id == model.TrainingId).Active == false)
            {
                throw new ArgumentException(
                    message: "Training is no longer active or there is no such a training at all");
            }

            var order = new Order()
            {
              
                

            };
            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();


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
                   SeatsLeft = training.OpenSeats-training.Orders.Count()

                },
                TrainingId = trainingId,
                UserId = userId,
                TotalPrice = (training.Recipe.RecipeProducts
                                  .Sum(rp => rp.Product.Price * (decimal)rp.Quantity) +
                              (decimal)training.Trainer.TaxPerTrainingForStudent) *
                             PlatformInterestForTrainingSession
            };

            return model;
        }
    }
}
