using Microsoft.AspNetCore.Mvc;

namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
