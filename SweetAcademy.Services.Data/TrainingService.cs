using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Chef;
using SweetAcademy.Web.ViewModels.Order;
using SweetAcademy.Web.ViewModels.Product;
using SweetAcademy.Web.ViewModels.Recipe;
using SweetAcademy.Web.ViewModels.Training;
using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Services.Data
{
    public class TrainingService : ITrainingService
    {
        private readonly SweetAcademyDbContext dbContext;
        public TrainingService(SweetAcademyDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<ICollection<TrainingViewModel>> GetAllActiveTrainingAsync()
        {

            var model = await dbContext.Trainings.Where(t => t.Active)
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .Include(t => t.Trainer)
                .Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Recipe = new ShowRecipeViewModel()
                    {
                        Active = t.Recipe.Active,
                        Description = t.Recipe.Description,
                        ImageUrl = t.Recipe.ImageUrl,
                    },
                    Active = t.Active,
                    StartDate = t.StartDate,
                    ChefId = t.ChefId,
                    OpenSeats = t.OpenSeats,
                    SeatsLeft = t.OpenSeats - t.Orders.Count()
                }).ToArrayAsync();

            return model;
        }
        public async Task<ICollection<TrainingViewModel>> GetAllTrainingAsync()
        {

            var model = await dbContext.Trainings
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .Include(t => t.Trainer)
                .Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Recipe = new ShowRecipeViewModel()
                    {
                        Active = t.Recipe.Active,
                        Description = t.Recipe.Description,
                        ImageUrl = t.Recipe.ImageUrl,
                    },
                    Active = t.Active,
                    StartDate = t.StartDate,
                    ChefId = t.ChefId,
                    OpenSeats = t.OpenSeats
                }).ToArrayAsync();

            return model;
        }
        public async Task<TrainingViewModel> ShowDetailsByIdAsync(int id)
        {
            var training = await dbContext.Trainings
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .ThenInclude(t => t.Product)
                .Include(t => t.Trainer)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (training == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            var model = new TrainingViewModel()
            {
                Id = training.Id,
                Name = training.Name,
                Recipe = new ShowRecipeViewModel()
                {
                    Active = training.Recipe.Active,
                    Description = training.Recipe.Description,
                    ImageUrl = training.Recipe.ImageUrl,
                },
                Active = training.Active,
                StartDate = training.StartDate,
                ChefId = training.ChefId,
                ChefFullName = training.Trainer.FullName,
                OpenSeats = training.OpenSeats,
                RecipeId = training.RecipeId,
                TrainingTotalPrice = decimal.Round((training.Recipe.RecipeProducts.Sum(rp => rp.Product.Price * rp.Quantity) + training.Trainer.TaxPerTrainingForStudent) * PlatformInterestForTrainingSession, 2, MidpointRounding.AwayFromZero)
            };
            return model;
        }

        public async Task DeActivateByIdAsync(int id)
        {
            var training = await this.dbContext.Trainings.FindAsync(id);
            if (training != null)
            {
                training.Active = false;
                await dbContext.SaveChangesAsync();
                return;
            }

            throw new NullReferenceException();
        }

        public async Task ActivateByIdAsync(int id)
        {
            var training = await this.dbContext.Trainings.FindAsync(id);
            if (training != null)
            {
                training.Active = true;
                await dbContext.SaveChangesAsync();
                return;
            }
            throw new NullReferenceException();
        }

        public async Task AddTrainingAsync(AddTrainingViewModel model)
        {
            var training = new Training()
            {
                Name = model.Name,
                ChefId = model.ChefId,
                RecipeId = model.RecipeId,
                StartDate = model.StartDate,
                OpenSeats = model.OpenSeats,
                Active = true
            };
            await dbContext.Trainings.AddAsync(training);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<DateTime>> GetTrainingDateAsync()
        {

            var dates = await dbContext.Trainings
                .Where(t => t.Active)
                .Select(t => t.StartDate.Date)
                .ToArrayAsync();
            return dates;

        }

        public async Task<ICollection<TrainingViewModel>> AllByChef(Guid chefId)
        {
            var model = await dbContext.Trainings.Where(t => t.ChefId == chefId)
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .Include(t => t.Trainer)
                .Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Recipe = new ShowRecipeViewModel()
                    {
                        Active = t.Recipe.Active,
                        Description = t.Recipe.Description,
                        ImageUrl = t.Recipe.ImageUrl,
                    },
                    Active = t.Active,
                    StartDate = t.StartDate,
                    ChefId = t.ChefId,
                    OpenSeats = t.OpenSeats,
                  
                }).OrderByDescending(t => t.Active).ThenBy(t => t.StartDate.Date).ToArrayAsync();

            return model;
        }
    }
}