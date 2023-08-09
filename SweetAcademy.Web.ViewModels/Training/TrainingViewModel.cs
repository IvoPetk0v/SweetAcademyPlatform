using SweetAcademy.Data.Models;

namespace SweetAcademy.Web.ViewModels.Training
{
    public class TrainingViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public int OpenSeats { get; set; }

        public int RecipeId { get; set; }

        public virtual Data.Models.Recipe Recipe { get; set; } = null!;
        public virtual ICollection<ApplicationUser> Participators { get; set; } = null!;

        public bool Active { get; set; }

        public Guid ChefId { get; set; }

        public string ChefFullName { get; set; }
        public virtual Data.Models.Chef Trainer { get; set; } = null!;
    }
}
