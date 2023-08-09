using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Training;

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
                ChefFullName = training.Trainer.FullName,
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

            var dates= await dbContext.Trainings
                .Where(t => t.Active)
                .Select(t => t.StartDate.Date)
                .ToArrayAsync();
            return dates;
         
        }

        public async Task<ICollection<TrainingViewModel>> AllByChef(Guid chefId)
        {
            var model = await dbContext.Trainings.Where(t=>t.ChefId==chefId)
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
                }).OrderByDescending(t=>t.Active).ThenBy(t=>t.StartDate.Date).ToArrayAsync();

            return model;
        }
    }
}