using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Web.Controllers
{
    public class RecipeController : BaseController
    {
        private IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> AddRecipe()
        {
            var model = await recipeService.LoadAddRecipeViewModelWithProductsAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRecipe(AddRecipeViewModel model)
        {
            try
            {
                recipeService.AddRecipeAsync(model);
                return Ok(200);
            }

            catch (Exception e)
            {
                return BadRequest(error: e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> AllRecipes()
        {
            var model = await recipeService.GetAllRecipesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await recipeService.ShowFullRecipeInfoAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await recipeService.DeactivatedRecipeAsync(id);
            return RedirectToAction("AllRecipes");
        }
    }
}
