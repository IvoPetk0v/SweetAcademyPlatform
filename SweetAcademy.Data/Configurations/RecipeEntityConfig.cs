
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class RecipeEntityConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(p => p.Active).HasDefaultValue(true);
        }
    }
}
