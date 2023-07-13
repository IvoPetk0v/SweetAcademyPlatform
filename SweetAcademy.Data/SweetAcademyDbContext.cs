using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetAcademy.Data
{
    public class SweetAcademyDbContext : IdentityDbContext
    {
        public SweetAcademyDbContext(DbContextOptions<SweetAcademyDbContext> options)
            : base(options)
        {
        }
    }
}