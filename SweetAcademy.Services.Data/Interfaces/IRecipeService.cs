using SweetAcademy.Web.ViewModels.Product;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IRecipeService
    {
        public Task<AddRecipeViewModel> LoadAddRecipeViewModelWithProducts();

    }
}
