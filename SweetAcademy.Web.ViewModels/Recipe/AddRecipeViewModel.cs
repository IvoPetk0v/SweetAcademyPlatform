using System.ComponentModel.DataAnnotations;

using static SweetAcademy.Common.EntityValidationConstants.Recipe;

namespace SweetAcademy.Web.ViewModels.Recipe
{
    public class AddRecipeViewModel
    {
        public class Recipe
        {
            public Recipe()
            {
                this.Products = new HashSet<string>();
            }

            [Required]
            [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
            public string Name { get; set; } = null!;

            [Required]
            [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
            public string Description { get; set; } = null!;

            [Required]
            [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
            public string ImageUrl { get; set; } = null!;

            [Required]
            [StringLength(StepsMaxLength, MinimumLength = StepsMinLength)]
            public string StepsJson { get; set; } = null!;

            [Required] 
            public virtual ICollection<string> Products { get; set; }

        }
    }
}
