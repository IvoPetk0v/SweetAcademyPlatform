using System.Reflection.Metadata;
using SweetAcademy.Data;
using SweetAcademy.Services.Data.Interfaces;

namespace SweetAcademy.Services.Data
{
    public class RecipeService :IRecipeService
    {
        private readonly SweetAcademyDbContext dbContext;

        public RecipeService(SweetAcademyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
