

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class ChefEntityConfig : IEntityTypeConfiguration<Chef>
    {
        private readonly HashSet<Chef> seeds = new HashSet<Chef>()
        {
            new Chef()
            {
                Id = Guid.Parse("E7ECBFE6-BE8C-4C46-AE6F-001BBD8A4182"),
                Active = true,
                ApplicationUserId = Guid.Parse("544B4C23-1F5E-4614-9FA8-08DB92B169A9"),
                FullName ="Steffy Cheffy",
                PhoneNumber = 0899999999,
                TaxPerTrainingForStudent = 30.50m
            }
        };
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.HasData(seeds);
        }

    }
}
