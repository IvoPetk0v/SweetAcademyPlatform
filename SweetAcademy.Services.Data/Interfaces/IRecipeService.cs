using SweetAcademy.Web.ViewModels.Product;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IRecipeService
    {
        public Task<AddRecipeViewModel> LoadAddRecipeViewModelWithProductsAsync();

        public Task AddRecipeAsync(AddRecipeViewModel addRecipeViewModel);

        public Task<ICollection<ShowRecipeViewModel>> GetAllRecipesAsync();

        public Task<ShowRecipeViewModel> ShowFullRecipeInfoAsync(int id);

    }
}
