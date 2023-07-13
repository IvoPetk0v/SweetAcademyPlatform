using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using static SweetAcademy.Common.EntityValidationConstants;


namespace SweetAcademy.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Products = new HashSet<Product>();
            this.Trainings = new HashSet<Training>();
            this.RecipeProducts = new HashSet<RecipeProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RecipeNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(RecipeDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(RecipeStepsMaxLength)]
        public string StepsJson { get; set; } = null!;

        [NotMapped]
        public ICollection<string> StepsCollection =>
            JsonConvert.DeserializeObject

        [Required]
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Training>? Trainings { get; set; }
        public virtual ICollection<RecipeProduct> RecipeProducts { get; set; }

    }
}