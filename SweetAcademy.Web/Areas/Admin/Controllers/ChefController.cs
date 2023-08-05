using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Chef;


namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    public class ChefController : BaseAdminController
    {
        private IChefService chefService;

        public ChefController(IChefService service)
        {
            this.chefService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var model = await chefService.LoadChefAddViewModelAsync();
                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest(error: e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddChefViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var reloadedModel= await chefService.LoadChefAddViewModelAsync();

                model.Users = reloadedModel.Users;
                    
                return View(model);
            }

            await this.chefService.AddChefAsync(model);
            return View();
        }
    }
}
