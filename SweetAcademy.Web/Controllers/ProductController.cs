using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Product;
using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Web.Controllers
{
    public class ProductController : BaseController
    {
        private IProductService productService;

        public ProductController(IProductService product)
        {
            this.productService = product;
        }

        [HttpGet]
        [Authorize(Roles = RoleAdminName)]
        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = RoleAdminName)]
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

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var model = await productService.GetAllProducts();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleAdminName)]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await productService.DeleteProductById(id);
            }
            catch (Exception e)
            {
                return BadRequest(error: e.Message);
            }
            return RedirectToAction("AllProducts");

        }
        [HttpGet]
        [Authorize(Roles = RoleAdminName)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await productService.GetProductById(id);
            return View(model);
        }
        
        [HttpPost]
        [Authorize(Roles = RoleAdminName)]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)

        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await productService.EditProduct(id, model);
            return RedirectToAction("AllProducts");
        }
    }
}
