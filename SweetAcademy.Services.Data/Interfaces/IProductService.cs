using Microsoft.AspNetCore.Mvc;
using SweetAcademy.Web.ViewModels.Product;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IProductService
    {
        public Task AddProductAsync(ProductViewModel model);
        public Task<ICollection<ProductViewModel>> GetAllProducts();
        public Task DeleteProductById(int id);
        public Task<ProductViewModel> GetProductById(int id);
        public Task EditProduct(int id, ProductViewModel model);
    }
}
