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
        public async Task<IActionResult> AllProducts()
        {
            var model = await productService.GetAllActiveProducts();
            return View(model);
        }


    }
}
