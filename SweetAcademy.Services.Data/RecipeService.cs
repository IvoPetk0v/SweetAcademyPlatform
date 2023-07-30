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
        public Task AddRecipeAsync(AddRecipeViewModel addRecipeViewModel)
        {
            var recipe = new Recipe()
            {
                Name = addRecipeViewModel.Name,
                Description = addRecipeViewModel.Description,
                ImageUrl = addRecipeViewModel.ImageUrl,
                StepsJson = addRecipeViewModel.StepsJson,
                Active = true

            };

            dbContext.Recipes.Add(recipe);
            dbContext.SaveChanges();
            dbContext.RecipesProducts.AddRangeAsync(addRecipeViewModel.Products
                 .Select(p => new RecipeProduct()
                 {
                     RecipeId = recipe.Id,
                     ProductId = p.Id,
                     Quantity = p.Quantity ?? 0
                 }).ToArray());
            dbContext.SaveChanges();
            return Task.FromResult(result: "ok");
        }
        public async Task<ICollection<ShowRecipeViewModel>> GetAllRecipesAsync()
        {
            var model = await dbContext.Recipes.Where(r => r.Active == true)
                .Include(r => r.RecipeProducts)
                .ThenInclude(r => r.Product)
                .Select(r => new ShowRecipeViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    TotalPrice = decimal.Round(r.RecipeProducts.Sum(rp => rp.Product.Price * (decimal)rp.Quantity), 2, MidpointRounding.AwayFromZero)
                }).ToArrayAsync();
            return model;
        }

        public Task<ShowRecipeViewModel> ShowFullRecipeInfoAsync(int id)
        {
            var model = dbContext.Recipes.Where(r => r.Id == id).Include(r => r.RecipeProducts)
                .ThenInclude(r => r.Product).Select(r => new ShowRecipeViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    TotalPrice = decimal.Round(r.RecipeProducts.Sum(rp => rp.Product.Price * (decimal)rp.Quantity), 2, MidpointRounding.AwayFromZero),
                    Steps = r.Steps,
                    Products = r.RecipeProducts.Select(p => new ProductViewModel()
                    {
                        Id = p.ProductId,
                        Name = p.Product.Name,
                        Price = p.Product.Price,
                        Quantity = p.Quantity,
                        Unit = p.Product.Unit,
                    }).ToArray(),
                }).FirstAsync();
            return model;
        }

        public async Task DeactivatedRecipeAsync(int id)
        {
            var recipe = await dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe != null)
            {
                recipe.Active = false;
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
