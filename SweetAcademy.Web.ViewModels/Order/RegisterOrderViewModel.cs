using SweetAcademy.Data.Models;
using System.ComponentModel.DataAnnotations;

using static SweetAcademy.Common.GeneralApplicationConstants;

namespace SweetAcademy.Web.ViewModels.Order
{
    public class RegisterOrderViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public int TrainingId { get; set; }

        public virtual Data.Models.Training OrderedTraining { get; set; } = null!;

        public decimal? TotalPrice =>
            (this.OrderedTraining.Recipe.RecipeProducts.Sum(rp => rp.Product.Price * (decimal)rp.Quantity) +
             (decimal)this.OrderedTraining.Trainer.TaxPerTrainingForStudent) * PlatformInterestForTrainingSession;
    }
}
