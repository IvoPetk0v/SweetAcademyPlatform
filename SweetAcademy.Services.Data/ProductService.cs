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

        public async Task<ICollection<ProductViewModel>> GetAllProducts()
        {
            var products = await dbContext.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Unit = p.Unit,
                    Price = p.Price
                }).ToArrayAsync();

            return products;
        }

        public async Task DeleteProductById(int id)
        {
            var productExist = dbContext.Products.Any(p => p.Id == id);

            if (!productExist)
            {
                throw new InvalidOperationException(
                    message: "Can`t delete the product because it`s not existing in the list.");
            }

            dbContext.Products.Remove(dbContext.Products.First(p => p.Id == id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var product = await dbContext.Products.FirstAsync(p => p.Id == id);
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Unit = product.Unit,
                Price = product.Price
            };
        }

        public async Task EditProduct(int id, ProductViewModel model)
        {
            var product = await dbContext.Products.FirstAsync(p => p.Id == id);
            product.Name = model.Name;
            product.Unit = model.Unit;
            product.Price = model.Price;

            await dbContext.SaveChangesAsync();
        }
    }
}