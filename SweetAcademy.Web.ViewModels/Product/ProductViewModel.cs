using System.ComponentModel.DataAnnotations;

using static SweetAcademy.Common.EntityValidationConstants.Product;

namespace SweetAcademy.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(UnitMaxLength, MinimumLength = UnitMinLength)]
        public string Unit { get; set; } = null!;

        [Required]
        [Range(0.00, 9999.99)]
        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public bool Active { get; set; }

    }
}
