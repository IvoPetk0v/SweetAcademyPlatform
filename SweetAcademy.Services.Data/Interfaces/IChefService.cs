using SweetAcademy.Web.ViewModels.Chef;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IChefService
    {
        public Task AddChefAsync (AddChefViewModel model);
        public Task<AddChefViewModel> LoadChefAddViewModelAsync();
    }
}
