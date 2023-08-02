using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles=RoleAdminName)]
    public class BaseAdminController : Controller
    {
      
    }
}
