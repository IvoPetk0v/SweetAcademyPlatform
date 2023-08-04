using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data;
using SweetAcademy.Web.ViewModels.Product;
using System.Data;
using SweetAcademy.Services.Data.Interfaces;

namespace SweetAcademy.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private IProductService productService;

        public ProductController(IProductService service)
        {
            this.productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var model = await productService.GetAllProductsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            try
            {
                await productService.AddProductAsync(model);
            }
            catch (Exception e)
            {
                return BadRequest(error: e.Message);
            }
            return RedirectToAction("AddProducts");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await productService.DeactivateProductByIdAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(error: e.Message);
            }
            return RedirectToAction("AllProducts");

        }
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var model = await productService.GetProductByIdAsync(id);
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, ProductViewModel model)

        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await productService.EditProductAsync(id, model);
            return RedirectToAction("AllProducts");
        }

        [HttpPost]
        public async Task<IActionResult> Activate(int id)
        {
            await productService.ActivateProductByIdAsync(id);
            return RedirectToAction("AllProducts");
        }
    }
}

