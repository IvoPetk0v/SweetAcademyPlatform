﻿using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data.Interfaces;

namespace SweetAcademy.Web.Controllers
{
   
    public class ChefController : BaseController
    {
        private IChefService chefService;

        public ChefController(IChefService service)
        {
            this.chefService=service;
        }

        public async Task<IActionResult>  All()
        {
            var model = await chefService.GetAllChefs();
            return View(model);
        }
    }
}