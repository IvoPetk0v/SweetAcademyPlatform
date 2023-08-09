using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SweetAcademy.Web.ViewModels.Home;
using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Web.Controllers
{
    public class HomeController : BaseController
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (this.User.IsInRole(RoleAdminName))
            {
                return this.RedirectToAction("Index","Home",new {Area = AdminAreaName});
            }
            else
            {
                return View();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}