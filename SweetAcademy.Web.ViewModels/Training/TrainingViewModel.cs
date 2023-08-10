using SweetAcademy.Web.ViewModels.Chef;
using SweetAcademy.Web.ViewModels.Order;
using SweetAcademy.Web.ViewModels.Recipe;

namespace SweetAcademy.Web.ViewModels.Training
{
    public class TrainingViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public int OpenSeats { get; set; }

        public int RecipeId { get; set; }

        public ShowRecipeViewModel Recipe { get; set; } = null!;
        public  ICollection<OrderUsersViewModel> Participators { get; set; } = null!;

        public bool Active { get; set; }

        public Guid ChefId { get; set; }

        public string ChefFullName { get; set; }=null!;
        public  ChefViewModel Trainer { get; set; } = null!;

        public decimal TrainingTotalPrice { get; set; }
    }
}
