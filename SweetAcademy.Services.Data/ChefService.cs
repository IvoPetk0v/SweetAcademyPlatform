using Microsoft.EntityFrameworkCore;

using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Chef;
using SweetAcademy.Web.ViewModels.User;

namespace SweetAcademy.Services.Data
{
    public class ChefService : IChefService
    {
        private readonly SweetAcademyDbContext dbContext;

        public ChefService(SweetAcademyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddChefAsync(AddChefViewModel model)
        {

            var chef = new Chef()
            {
                FullName = model.FullName,
                ApplicationUserId = model.ApplicationUserId,
                PhoneNumber = model.PhoneNumber,
                Active = true,
                TaxPerTrainingForStudent = model.TaxPerTrainingForStudent,

            };
            await this.dbContext.Chefs.AddAsync(chef);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddChefViewModel> LoadChefAddViewModelAsync()
        {
            var model = new AddChefViewModel();
            var users = await dbContext.ApplicationUsers.Include(a => a.Chef).Where(a => a.Chef!.ApplicationUserId != a.Id).Select(a => new UserViewModel()
            {
                UserName = a.UserName,
                Id = a.Id
            }).ToArrayAsync();
            model.Users = users;
            return model;
        }

        public async Task<ICollection<ChefViewModel>> GetAllChefs()
        {
            var model = await dbContext.Chefs.Include(c => c.User).Select(c => new ChefViewModel()
            {
                Id = c.Id,
                ApplicationUserId = c.ApplicationUserId,
                FullName = c.FullName,
                PhoneNumber = $"+359{c.PhoneNumber}",
                TaxPerTrainingForStudent = c.TaxPerTrainingForStudent,
                Active = c.Active,
                CouchingSession = c.CouchingSession,
                Email = c.User.UserName,
            }).ToArrayAsync();
            return model;
        }

        public async Task<ChefViewModel> GetChefByIdAsync(Guid id)
        {
            var chef = await dbContext.Chefs.FirstOrDefaultAsync(c => c.Id == id);
            if (chef != null)
            {
                var model = new ChefViewModel()
                {
                    Id = chef.Id,
                    ApplicationUserId = chef.ApplicationUserId,
                    FullName = chef.FullName,
                    PhoneNumber = chef.PhoneNumber.ToString(),
                    TaxPerTrainingForStudent = chef.TaxPerTrainingForStudent,
                };
                return model;
            }
            throw new NullReferenceException();
        }

        public async Task EditAsync(ChefViewModel model)
        {
            var chef = await dbContext.Chefs.FirstOrDefaultAsync(c => c.Id == model.Id);
            if (chef != null)
            {
                chef.FullName = model.FullName;
                chef.PhoneNumber = int.Parse(model.PhoneNumber);
                chef.TaxPerTrainingForStudent = model.TaxPerTrainingForStudent;
                await dbContext.SaveChangesAsync();
                return;
            }
            throw new NullReferenceException();
        }

        public async Task DeactivateChefAsync(Guid id)
        {
            var chef = await dbContext.Chefs.FirstOrDefaultAsync(r => r.Id == id);
            if (chef != null)
            {
                chef.Active = false;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task ActivateRecipeAsync(Guid id)
        {
            var chef = await dbContext.Chefs.FirstOrDefaultAsync(r => r.Id == id);
            if (chef != null)
            {
                chef.Active = true;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
