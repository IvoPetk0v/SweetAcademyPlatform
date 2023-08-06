using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data;
using SweetAcademy.Services.Data.Interfaces;
using System.Data;

namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    public class TrainingController : BaseAdminController
    {
        private readonly ITrainingService trainingService;

        public TrainingController(ITrainingService service)
        {
            this.trainingService = service;
        }
        public async Task<IActionResult> All()
        {
            var model = await trainingService.GetAllTrainingAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = await trainingService.ShowDetailsByIdAsync(id);
                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("All");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.trainingService.DeActivateByIdAsync(id);

                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
            try
            {
                await this.trainingService.ActivateByIdAsync(id);

                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
