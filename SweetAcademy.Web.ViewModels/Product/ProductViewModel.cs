using System.ComponentModel.DataAnnotations;

using static SweetAcademy.Common.EntityValidationConstants.Product;

namespace SweetAcademy.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            this.Products = new HashSet<string>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(UnitMaxLength, MinimumLength = UnitMinLength)]
        public string Unit { get; set; } = null!;

        [Required]
        [Range(0, 5)]
        public int Category { get; set; }

        [Required]
        [Range(0, 9999)]
        public decimal PricePerPackage { get; set; }

        public virtual ICollection<string> Products { get; set; }
    }
}
