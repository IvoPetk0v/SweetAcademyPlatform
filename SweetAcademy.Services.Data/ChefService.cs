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
            var users = await dbContext.ApplicationUsers.Include(a=>a.Chef).Where(a => a.Chef!.ApplicationUserId!=a.Id).Select(a => new UserViewModel()
            {
                UserName = a.UserName,
                Id = a.Id
            }).ToArrayAsync();
            model.Users = users;
            return model;

        }
    }
}
