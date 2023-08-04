using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data.Interfaces;
using System.Data;

namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    public class RecipeController : BaseAdminController
    {
        private IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
                this.recipeService=recipeService;
        }
        public async Task<IActionResult> AllRecipes()
        {
            var model = await recipeService.GetAllRecipesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
           await recipeService.ActivateRecipeAsync(id);
            return RedirectToAction("AllRecipes");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await recipeService.DeactivatedRecipeAsync(id);
            return RedirectToAction("AllRecipes");
        }
    }
}
