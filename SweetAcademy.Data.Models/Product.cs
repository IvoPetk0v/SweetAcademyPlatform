using System.ComponentModel.DataAnnotations;

using static SweetAcademy.Common.EntityValidationConstants;
namespace SweetAcademy.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.RecipeProducts = new HashSet<RecipeProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ProductUnitMaxLength)]
        public string Unit { get; set; }= null!;

        [Required] 
        public ProductCategoryEnum Category { get; set; }

        [Required]
        public decimal Price { get; set; } 

        public virtual ICollection<RecipeProduct> RecipeProducts { get; set; }
    }
}
