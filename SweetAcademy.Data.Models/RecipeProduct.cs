using System.ComponentModel.DataAnnotations.Schema;

namespace SweetAcademy.Data.Models
{
    public class RecipeProduct
    {
        public int RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; } = null!;
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }= null!;


    }
}
