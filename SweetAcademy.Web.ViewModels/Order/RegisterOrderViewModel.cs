using SweetAcademy.Data.Models;
using System.ComponentModel.DataAnnotations;
using SweetAcademy.Web.ViewModels.Training;


namespace SweetAcademy.Web.ViewModels.Order
{
    public class RegisterOrderViewModel
    {

        [Required]
        public Guid UserId { get; set; }

        public virtual ApplicationUser? User { get; set; } 

        [Required]
        public int TrainingId { get; set; }

        public TrainingViewModel? OrderedTraining { get; set; } 

        [Required]
        public decimal TotalPrice { get; set; }

    }
}
