using Microsoft.AspNetCore.Mvc;

namespace SweetAcademy.Web.Controllers
{
    public class TrainingController : BaseController
    {

        public IActionResult All()
        {
            return View();
        }
    }
}
