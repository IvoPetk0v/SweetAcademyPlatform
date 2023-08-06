using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SweetAcademy.Services.Data.Interfaces;
using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Web.Controllers
{
    public class TrainingController : BaseController
    {
        private readonly ITrainingService trainingService;

        public TrainingController(ITrainingService service)
        {
            this.trainingService = service;
        }
        public async Task<IActionResult> All()
        {
            var model = await trainingService.GetAllActiveTrainingAsync();
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
    }
}
