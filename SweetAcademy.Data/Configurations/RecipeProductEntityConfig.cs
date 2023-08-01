using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class RecipeProductEntityConfig :IEntityTypeConfiguration<RecipeProduct>
    {
        private readonly HashSet<RecipeProduct> seeds = new HashSet<RecipeProduct>()
        {
            new RecipeProduct()
            {
                ProductId = 1,
                RecipeId = 1,
                Quantity = 5

            },
            new RecipeProduct()
            {
                ProductId = 2,
                RecipeId = 1,
                Quantity = 1
            },
            new RecipeProduct()
            {
                ProductId = 3,
                RecipeId = 1,
                Quantity = 4
            },
            new RecipeProduct()
            {
                ProductId = 1,
                RecipeId = 2,
                Quantity = 5
            },
            new RecipeProduct()
            {
                ProductId = 2,
                RecipeId = 2
            },
            new RecipeProduct()
            {
                ProductId = 3,
                RecipeId = 2,
                Quantity = 4
            },
        };
        public void Configure(EntityTypeBuilder<RecipeProduct> builder)
        {
            builder.HasKey(pk => new { pk.RecipeId, pk.ProductId });
            builder.HasData(seeds);
        }
    }
}
