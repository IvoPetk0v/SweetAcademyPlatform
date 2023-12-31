﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Training;


namespace SweetAcademy.Web.Controllers
{
    public class TrainingController : BaseController
    {
        private readonly ITrainingService trainingService;
        private readonly IRecipeService recipeService;

        public TrainingController(ITrainingService service, IRecipeService recipeService)
        {
            this.trainingService = service;
            this.recipeService = recipeService;
        }
        public async Task<IActionResult> All()
        {
            ViewBag.IsFilteredByChefId = false;
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
            catch (Exception )
            {
                return RedirectToAction("All");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddTrainingViewModel();
            var allRecipes = await recipeService.GetAllActiveRecipesAsync();
            model.Recipes = allRecipes;

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
        [HttpGet]
        public async Task<IActionResult> AllByChef(Guid id)
        {
            ViewBag.IsFilteredByChefId = true;
           var model =await trainingService.AllByChef(id);
           return View("All", model);
        }
    }
}
