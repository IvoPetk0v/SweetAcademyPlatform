using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data
{
    public class SweetAcademyDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public SweetAcademyDbContext(DbContextOptions<SweetAcademyDbContext> options)
            : base(options)
        {
        }
        
    }
}