using SweetAcademy.Web.ViewModels.Order;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IOrderService
    {
        public Task CreateAnOrderAsync(RegisterOrderViewModel model, Guid userId);
        public Task<RegisterOrderViewModel> LoadOrderInfoAsync(int trainingId, Guid userId);
    }
}