using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Recipe;
using static SweetAcademy.Common.GeneralApplicationConstants;

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
                recipeService.AddRecipe(model);
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
          
            var model = await recipeService.GetAllActiveRecipesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            try
            {
                var model = await recipeService.ShowFullRecipeInfoAsync(id);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("AllRecipes");
            }

        }

    }
}
