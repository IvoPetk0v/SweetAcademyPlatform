
using SweetAcademy.Data.Models;


namespace SweetAcademy.Web.ViewModels.Order
{
    public class OrderUsersViewModel
    {

        public Guid UserId { get; set; }

        public  ApplicationUser User { get; set; } = null!;


        public int TrainingId { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
