using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SweetAcademy.Web.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult AddProducts()
        {
            return View();
        }
    }
}
