using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Web.Controllers
{
    public class RecipeController : BaseController
    {
        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRecipe(AddRecipeViewModel model)
        {

            return View(model);
        }
    }
}
