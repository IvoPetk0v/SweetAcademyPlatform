
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class ApplicationUserEntityConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        private readonly HashSet<ApplicationUser> seeds = new HashSet<ApplicationUser>()
        {
            new ApplicationUser()
            {
                Id = Guid.Parse("5BFC2446-3FD2-4990-9265-08DB8AAD116C"),
                UserName = "admin@admin.bg",
                NormalizedEmail = "ADMIN@ADMIN.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEHXuw6dYlxC8AEJ5dq817hzjCU/O72xLYs+NeKUXL/Rdikx4mt6Q3+3jzAhARG4NEA==",
                SecurityStamp = "EF2DAKHPWV6KTXCJF4JR2RQMHEXPPGQ3",
                ConcurrencyStamp = "df94bcd6-62ee-46f1-a089-0576b12308bf",
                LockoutEnabled = true,
            },
         
            new ApplicationUser()
            {
                Id = Guid.Parse("21D6DFFE-E209-4DCC-9FA9-08DB92B169A9"),
                UserName = "ip@customer.bg",
                NormalizedEmail = "IP@CUSTOMER.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEO1XTr6PzJ1+1+fdYOEB+Dq8GcV5kClGxOY90gYEs0MmzeRZA2G7eGL205oEaCYbcg==",
                SecurityStamp = "2WCQ3I2BZ2DU4YJT62ZMCHKVUCO2PKGL",
                ConcurrencyStamp = "f420ec05-4560-49a1-a22a-3a7c6b0ffc9a",
                LockoutEnabled = true,
            }
        };
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(seeds);
        }
    }
}
