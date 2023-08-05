using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetAcademy.Data.Configurations;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data
{
    public class SweetAcademyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<RecipeProduct> RecipesProducts { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<Chef> Chefs { get; set; }=null!;

        public SweetAcademyDbContext(DbContextOptions<SweetAcademyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var configAssembly = Assembly.GetAssembly(typeof(SweetAcademyDbContext)) ??
                                 Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(ProductEntityConfig.Seed());
            builder.Entity<Recipe>().HasData(RecipeEntityConfig.Seed());
            builder.Entity<RecipeProduct>().HasData(RecipeProductEntityConfig.Seed());
            builder.Entity<Chef>().HasData(ChefEntityConfig.Seed());
            builder.Entity<Training>().HasData(TrainingEntityConfig.Seed());
        }

    }
}