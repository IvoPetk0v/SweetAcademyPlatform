using System.Collections.Immutable;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Product;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Services.Data
{
    public class RecipeService : IRecipeService
    {
        private readonly SweetAcademyDbContext dbContext;

        public RecipeService(SweetAcademyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AddRecipeViewModel> LoadAddRecipeViewModelWithProductsAsync()
        {
            var recipeModel = new AddRecipeViewModel();
            var products = await dbContext.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Unit = p.Unit,
                }).ToArrayAsync();
            recipeModel.Products = products;
            return recipeModel;
        }
        public async Task AddRecipeAsync(AddRecipeViewModel addRecipeViewModel)
        {
            var recipe = new Recipe
            {
                Name = addRecipeViewModel.Name,
                Description = addRecipeViewModel.Description,
                ImageUrl = addRecipeViewModel.ImageUrl,
                StepsJson = addRecipeViewModel.StepsJson,
                RecipeProducts = addRecipeViewModel.Products
                    .Select(p => new RecipeProduct()
                    {
                        ProductId = p.Id,
                        Quantity = p.Quantity ?? 0,
                    }).ToArray(),
                Active = true
            };

            await dbContext.Recipes.AddAsync(recipe);
            await dbContext.SaveChangesAsync();
        }
        public async Task<ICollection<ShowRecipeViewModel>> GetAllRecipesAsync()
        {
            var model = await dbContext.Recipes
                .Include(r => r.RecipeProducts)
                .ThenInclude(r => r.Product)
                .Select(r => new ShowRecipeViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    TotalPrice = r.TotalPrice
                }).ToArrayAsync();
            return model;
        }
    }
}
