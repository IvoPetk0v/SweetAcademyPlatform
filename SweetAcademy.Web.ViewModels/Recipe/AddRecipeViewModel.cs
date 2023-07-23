using System.ComponentModel.DataAnnotations;
using static SweetAcademy.Common.EntityValidationConstants.Recipe;

namespace SweetAcademy.Web.ViewModels.Recipe
{
    public class AddRecipeViewModel
    {

        public AddRecipeViewModel()
        {
            this.Products = new Dictionary<string, int>();
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
        public Dictionary<string, int> Products
        {
            get => Products;
            set
            {
                if (value.Count == 0)
                {
                    throw new NullReferenceException(message: "Product list can`t be empty");
                }
                if (value.Values.Any(v => v <= 0))
                {
                    throw new ArgumentException(message: "Products quantities must be greater than 0");
                }

                this.Products = value;

            }
        }
    }
}

