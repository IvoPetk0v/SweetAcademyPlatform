using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SweetAcademy.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public Guid GetUserId()
        {
            Guid id = Guid.Empty;

            if (User != null)
            {
                id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            return id;
        }
    }
}
