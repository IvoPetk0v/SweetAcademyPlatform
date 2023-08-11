using SweetAcademy.Web.ViewModels.Training;
using SweetAcademy.Web.ViewModels.User;


namespace SweetAcademy.Web.ViewModels.Order
{
    public class OrdersUserViewModel
    {

        public Guid UserId { get; set; }

        public  UserViewModel User { get; set; } = null!;
        public string TotalPrice { get; set; } = null!;
        public TrainingViewModel Trainings { get; set; } = null!;

    }
}
