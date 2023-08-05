
using SweetAcademy.Web.ViewModels.Product;

namespace SweetAcademy.Services.Data.Interfaces
{
    public interface IProductService
    {
        public Task AddProductAsync(ProductViewModel model);
        public Task<ICollection<ProductViewModel>> GetAllActiveProducts();
        public Task<ICollection<ProductViewModel>> GetAllProductsAsync();
        public Task DeactivateProductByIdAsync(int id);
        public Task<ProductViewModel> GetProductByIdAsync(int id);
        public Task EditProductAsync(int id, ProductViewModel model);

        public Task ActivateProductByIdAsync(int id);
    }
}
