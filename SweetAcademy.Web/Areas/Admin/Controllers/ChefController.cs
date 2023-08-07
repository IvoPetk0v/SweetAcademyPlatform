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
                var reloadedModel = await chefService.LoadChefAddViewModelAsync();

                model.Users = reloadedModel.Users;

                return View(model);
            }

            await this.chefService.AddChefAsync(model);
            return View();
        }

        public async Task<IActionResult> All()
        {
            var model = await chefService.GetAllChefsAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var model = await chefService.GetChefByIdAsync(id);

                return View(model);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit( Guid id ,ChefViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await chefService.EditAsync(model);
                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await chefService.DeactivateChefAsync(id);
                return RedirectToAction("All");
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Activate(Guid id)
        {
            try
            {
                await chefService.ActivateRecipeAsync(id);
                return RedirectToAction("All");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
         
        }
    }
}
