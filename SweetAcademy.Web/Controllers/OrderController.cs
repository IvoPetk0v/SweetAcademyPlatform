using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Order;

namespace SweetAcademy.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService service)
        {
            this.orderService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Register(int id)
        {
            var userId = this.GetUserId();
            var model = new RegisterOrderViewModel();
            try
            {
                 model = await orderService.LoadOrderInfoAsync(id, userId);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Training");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterOrderViewModel model)
        {
            var userId = this.GetUserId();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await orderService.CreateAnOrderAsync(model, userId);
                return Ok();
                // return RedirectToAction("OrderList");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        public IActionResult OrderList()
        {
            return View();
        }
    }
}
