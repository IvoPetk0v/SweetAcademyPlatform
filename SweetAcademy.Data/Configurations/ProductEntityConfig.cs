using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class ProductEntityConfig : IEntityTypeConfiguration<Product>
    {
        private readonly HashSet<Product> seeds = new HashSet<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Sugar",
                Price = 0.20m,
                Unit = "50 g."
            },
            new Product
            {
                Id = 2,
                Name = "Butter",
                Price = 6.99m,
                Unit = "250 g."
            },
            new Product
            {
                Id = 3,
                Name = "Chocolate",
                Price = 3.50m,
                Unit = "90 g."
            },
            new Product()
            {
                Id = 4,
                Name = "Milk",
                Price = 1.5m,
                Unit = "500 ml"
            }

        };

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.HasKey(p => p.Id);

            builder.HasData(seeds);
        }

    }
}
