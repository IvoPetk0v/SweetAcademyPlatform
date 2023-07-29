using Microsoft.AspNetCore.Mvc;

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
       
        public async  Task<IActionResult> AddRecipe()
        {
          var model= await recipeService.LoadAddRecipeViewModelWithProducts();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRecipe(AddRecipeViewModel model)
        {
            Console.WriteLine(model);
            return Ok(200);
        }
    }
}
