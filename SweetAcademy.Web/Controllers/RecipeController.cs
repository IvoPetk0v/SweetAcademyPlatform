using Microsoft.AspNetCore.Mvc;

namespace SweetAcademy.Web.Controllers
{
    public class RecipeController : BaseController
    {
        [HttpGet]
        public IActionResult AddRecipe()
        {
            return View();
        }
    }
}
