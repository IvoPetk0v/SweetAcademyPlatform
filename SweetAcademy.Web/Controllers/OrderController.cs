using Microsoft.AspNetCore.Mvc;

namespace SweetAcademy.Web.Controllers
{
    public class OrderController : BaseController
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
