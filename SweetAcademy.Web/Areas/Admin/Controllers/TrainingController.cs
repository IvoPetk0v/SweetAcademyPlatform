using Microsoft.AspNetCore.Mvc;

using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Training;


namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    public class TrainingController : BaseAdminController
    {
        private readonly ITrainingService trainingService;
        private readonly IRecipeService recipeService;
        private readonly IChefService chefService;

        public TrainingController(ITrainingService service, IRecipeService recipeService, IChefService chefService)
        {
            this.trainingService = service;
            this.recipeService = recipeService;
            this.chefService = chefService;
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
            catch (Exception)
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
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddTrainingViewModel();
            var allRecipes = await recipeService.GetAllActiveRecipesAsync();
            var allChefs = await chefService.GetAllChefsAsync();
            model.Recipes = allRecipes;
            model.Chefs = allChefs;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTrainingViewModel model)
        {
            var dates = await trainingService.GetTrainingDateAsync();

            if (!ModelState.IsValid || model.StartDate.Date <= DateTime.Today)
            {
                var allRecipes = await recipeService.GetAllActiveRecipesAsync();
                model.Recipes = allRecipes;

                ModelState.AddModelError(
                    key: "StartDate",
                    errorMessage: $"Date must be at least one day forward from today - ({DateTime.Today:dd/MM/yyyy}) !");

                return View(model);
            }

            if (dates.Contains(model.StartDate.Date))
            {
                var allRecipes = await recipeService.GetAllActiveRecipesAsync();

                model.Recipes = allRecipes;

                ModelState.AddModelError(
                    key: "StartDate",
                    errorMessage:
                    $"The Date - ({model.StartDate.Date:dd/MM/yyyy}) is already booked for another training! Please select another one or contact Administration");

                return View(model);
            }
            try
            {
                await trainingService.AddTrainingAsync(model);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return BadRequest(error: "Something get wrong adding this training.Please try again or contact Administration.");
            }
        }
    }
}
