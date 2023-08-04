using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetAcademy.Data;
using SweetAcademy.Data.Models;
using SweetAcademy.Services.Data.Interfaces;
using SweetAcademy.Web.ViewModels.Product;

namespace SweetAcademy.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly SweetAcademyDbContext dbContext;

        public ProductService(SweetAcademyDbContext context)
        {
            this.dbContext = context;
        }
        public async Task AddProductAsync(ProductViewModel model)
        {
            var isAlreadyCreated = dbContext.Products.Any(p => p.Name.ToLower() == model.Name.ToLower());
            if (isAlreadyCreated)
            {
                throw new OperationCanceledException(message: "The product already existing, maybe want to edit it ?");
            }

            var product = new Product()
            {
                Name = model.Name,
                Unit = model.Unit,
                Price = model.Price
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ProductViewModel>> GetAllActiveProducts()
        {
            var products = await dbContext.Products.Where(p => p.Active)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Unit = p.Unit,
                    Price = p.Price,
                }).ToArrayAsync();

            return products;
        }
        public async Task<ICollection<ProductViewModel>> GetAllProductsAsync()
        {
            var products = await dbContext.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Unit = p.Unit,
                    Price = p.Price,
                    Active = p.Active
                }).ToArrayAsync();

            return products;
        }

        public async Task DeactivateProductByIdAsync(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                product.Active = false;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var product = await dbContext.Products.FirstAsync(p => p.Id == id);
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Unit = product.Unit,
                Price = product.Price,
            };
        }

        public async Task EditProductAsync(int id, ProductViewModel model)
        {
            var product = await dbContext.Products.FirstAsync(p => p.Id == id);
            product.Name = model.Name;
            product.Unit = model.Unit;
            product.Price = model.Price;

            await dbContext.SaveChangesAsync();
        }

        public async Task ActivateProductByIdAsync(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                product.Active = true;
                await dbContext.SaveChangesAsync();
            }

        }
    }
}