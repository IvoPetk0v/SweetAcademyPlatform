
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IRecipeService
    {
        public Task<AddRecipeViewModel> LoadAddRecipeViewModelWithProductsAsync();

        public Task AddRecipe(AddRecipeViewModel addRecipeViewModel);

        public Task<ICollection<ShowRecipeViewModel>> GetAllActiveRecipesAsync();
        public Task<ICollection<ShowRecipeViewModel>> GetAllRecipesAsync();

        public Task<ShowRecipeViewModel> ShowFullRecipeInfoAsync(int id);
        public Task DeactivateRecipeAsync(int id);
        public Task ActivateRecipeAsync(int id);

    }
}
