using System.Data;
using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Training;

namespace SweetAcademy.Services.Data
{
    public class TrainingService : ITrainingService
    {
        private readonly SweetAcademyDbContext dbContext;
        public TrainingService(SweetAcademyDbContext context,IRecipeService service)
        {
            this.dbContext = context;
        }

        public async Task<ICollection<TrainingViewModel>> GetAllActiveTrainingAsync()
        {
         
            var model = await dbContext.Trainings.Where(t => t.Active)
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .Include(t=>t.Trainer)
                .Select(t => new TrainingViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Recipe = t.Recipe,
                    Trainer = t.Trainer,
                    Active = t.Active,
                    StartDate = t.StartDate,
                    ChefId = t.ChefId,
                    OpenSeats = t.OpenSeats,
                    Participators = t.Participators,
                    RecipeId = t.RecipeId
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
                    Recipe = t.Recipe,
                    Trainer = t.Trainer,
                    Active = t.Active,
                    StartDate = t.StartDate,
                    ChefId = t.ChefId,
                    OpenSeats = t.OpenSeats,
                    Participators = t.Participators,
                    RecipeId = t.RecipeId
                }).ToArrayAsync();

            return model;
        }
        public async Task<TrainingViewModel> ShowDetailsByIdAsync(int id)
        {
            var training = await dbContext.Trainings
                .Include(t => t.Recipe)
                .ThenInclude(t => t.RecipeProducts)
                .ThenInclude(t=>t.Product)
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
                Recipe = training.Recipe,
                Active = training.Active,
                StartDate = training.StartDate,
                ChefId = training.ChefId,
                OpenSeats = training.OpenSeats,
                Participators = training.Participators,
                RecipeId = training.RecipeId,
                Trainer = training.Trainer
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
    }
}