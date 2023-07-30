using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

using static SweetAcademy.Common.EntityValidationConstants.Recipe;


namespace SweetAcademy.Data.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Trainings = new HashSet<Training>();
            this.RecipeProducts = new HashSet<RecipeProduct>();
           
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(StepsMaxLength)]
        public string StepsJson { get; set; } = null!;

        [NotMapped]
        public ICollection<string> Steps =>
            JsonConvert.DeserializeObject<ICollection<string>>(this.StepsJson);

        [Required]
        public virtual ICollection<RecipeProduct> RecipeProducts { get; set; }
        public virtual ICollection<Training>? Trainings { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }

    }
}