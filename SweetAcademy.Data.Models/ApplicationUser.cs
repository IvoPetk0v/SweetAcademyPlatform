using Microsoft.AspNetCore.Identity;

namespace SweetAcademy.Data.Models
{
    /// <summary>
    /// Custom user class working with default ASP.NET Core Identity.
    /// There are collection for Orders and Trainings bought by the user.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>();
            this.Training = new HashSet<Training>();
        }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Training>? Training { get; set; }

        public virtual Chef? Chef { get; set; }
    }
}
