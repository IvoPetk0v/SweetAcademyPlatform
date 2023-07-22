using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class ProductEntityConfig:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.HasKey(p => p.Id);
        }
    }
}
