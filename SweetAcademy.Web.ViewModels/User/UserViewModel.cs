

using SweetAcademy.Data.Models;

namespace SweetAcademy.Web.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;

        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Training>? Training { get; set; }

        public virtual Data.Models.Chef? Chef { get; set; }

    }
}
