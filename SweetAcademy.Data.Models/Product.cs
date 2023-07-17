using System.ComponentModel.DataAnnotations;

using static SweetAcademy.Common.EntityValidationConstants.Product;

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
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(UnitMaxLength)]
        public string Unit { get; set; }= null!;

        [Required] 
        public ProductCategoryEnum Category { get; set; }

        [Required]
        public decimal PricePerPackage { get; set; } 

        public virtual ICollection<RecipeProduct> RecipeProducts { get; set; }
    }
}
