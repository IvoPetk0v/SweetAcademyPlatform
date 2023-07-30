
using System.Runtime.CompilerServices;
using SweetAcademy.Web.ViewModels.Product;

namespace SweetAcademy.Web.ViewModels.Recipe
{
    public class ShowRecipeViewModel
    {
        public ShowRecipeViewModel()
        {
            this.Products = new List<ProductViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public ICollection<string> Steps { get; set; } = null!;
        public ICollection<ProductViewModel> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
