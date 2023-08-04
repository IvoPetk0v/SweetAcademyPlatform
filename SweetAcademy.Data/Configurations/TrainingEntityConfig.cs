
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
            builder.Property(p => p.Active).HasDefaultValue(true);
        }

        public static HashSet<Training> Seed()
        {
            HashSet<Training> seeds = new HashSet<Training>()
            {
                new Training()
                {
                    Id = 1,
                    Name = "Learn how to make Lava Cake like a pro with Stef",
                    OpenSeats = 1,
                    RecipeId = 1,
                    StartDate = DateTime.Parse("12/2/2024 20:30"),
                    Active = true,
                    ChefId = Guid.Parse("E7ECBFE6-BE8C-4C46-AE6F-001BBD8A4182"),

                }
            };
            return seeds;
        }
    }
}
