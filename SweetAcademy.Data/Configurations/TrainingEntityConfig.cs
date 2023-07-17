
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
   
    public class TrainingEntityConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasOne(t => t.Trainer).WithMany(c => c.CouchingSession).HasForeignKey(t => t.ChefId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
