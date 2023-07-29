using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SweetAcademy.Data;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Product;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Services.Data
{
    public class RecipeService :IRecipeService
    {
        private readonly SweetAcademyDbContext dbContext;

        public RecipeService(SweetAcademyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddRecipeViewModel> LoadAddRecipeViewModelWithProducts()
        {
            var recipeModel= new AddRecipeViewModel();
            var products = await dbContext.Products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Unit = p.Unit,
            }).ToArrayAsync();
            recipeModel.Products = products;
            return recipeModel;
        }
    }
}
