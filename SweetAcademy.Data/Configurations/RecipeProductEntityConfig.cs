using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class RecipeProductEntityConfig :IEntityTypeConfiguration<RecipeProduct>
    {
        public void Configure(EntityTypeBuilder<RecipeProduct> builder)
        {
            builder.HasKey(pk => new { pk.RecipeId, pk.ProductId });
        }
    }
}
