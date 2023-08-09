using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    internal class OrderEntityConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.TotalPrice).HasPrecision(6, 2);
        }
    }
}
