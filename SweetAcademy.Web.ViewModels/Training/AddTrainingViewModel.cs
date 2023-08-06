using System.ComponentModel.DataAnnotations;
using SweetAcademy.Web.ViewModels.Recipe;
using static SweetAcademy.Common.EntityValidationConstants.TrainingValidation;

namespace SweetAcademy.Web.ViewModels.Training
{
    public class AddTrainingViewModel
    {
        public AddTrainingViewModel()
        {
            this.Recipes = new HashSet<ShowRecipeViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(1,KitchenMaxSlots)]
        public int OpenSeats { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public Guid ChefId { get; set; }

        public ICollection<ShowRecipeViewModel> Recipes { get; set; }

    }
}
