

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class ChefEntityConfig : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.Property(c => c.Active).HasDefaultValue(true);

        }

        public static HashSet<Chef> Seed()
        {
            HashSet<Chef> seeds = new HashSet<Chef>() {
                new Chef()
            {
                Id = Guid.Parse("E7ECBFE6-BE8C-4C46-AE6F-001BBD8A4182"),
                Active = true,
                ApplicationUserId = Guid.Parse("5BFC2446-3FD2-4990-9265-08DB8AAD116C"),
                FullName = "Steffy Cheffy",
                PhoneNumber = 899999999,
                TaxPerTrainingForStudent = 30.50m
            }};
            return seeds;
        }
    }
}
