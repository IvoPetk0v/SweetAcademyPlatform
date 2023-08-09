using Microsoft.AspNetCore.Mvc;

namespace SweetAcademy.Web.Controllers
{
    public class OrderController : BaseController
    {
        [HttpGet]
        public IActionResult Register(int id)
        {
            return View();
        }
    }
}
