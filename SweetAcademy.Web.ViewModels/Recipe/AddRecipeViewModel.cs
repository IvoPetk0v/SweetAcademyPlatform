using System.ComponentModel.DataAnnotations;
using SweetAcademy.Web.ViewModels.Product;
using static SweetAcademy.Common.EntityValidationConstants.Recipe;

namespace SweetAcademy.Web.ViewModels.Recipe
{
    public class AddRecipeViewModel
    {

        public AddRecipeViewModel()
        {
            this.Products = new List<ProductViewModel>();
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
        public ICollection<ProductViewModel> Products { get; set; }
    }
}

