using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetAcademy.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        public int TrainingId { get; set; }

        [ForeignKey(nameof(TrainingId))]
        public virtual Training OrderedTraining { get; set; } = null!;

        public decimal? TotalPrice => this.OrderedTraining.Recipe.RecipeProducts.Sum(rp => rp.Product.Price * (decimal)rp.Quantity) +
                                     this.OrderedTraining.Trainer.TaxPerTrainingForStudent;
    }
}
