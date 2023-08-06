using SweetAcademy.Web.ViewModels.Chef;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IChefService
    {
        public Task AddChefAsync (AddChefViewModel model);
        public Task<AddChefViewModel> LoadChefAddViewModelAsync();

        public Task<ICollection<ChefViewModel>> GetAllChefs();
        public Task<ChefViewModel> GetChefByIdAsync(Guid id);
        public Task EditAsync (ChefViewModel model);
        public Task DeactivateChefAsync(Guid id);
        public Task ActivateRecipeAsync(Guid id);
        public Task<Guid> GetChefIdByUserIdAsync(Guid userId);
        public Task<bool> ChefExistByUserIdAsync(Guid userId);
    }
}
