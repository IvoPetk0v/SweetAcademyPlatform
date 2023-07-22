using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Product;

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
        public IActionResult AddProducts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductViewModel model)
        {
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
    }
}
