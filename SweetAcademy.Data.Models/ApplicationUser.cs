using Microsoft.AspNetCore.Identity;

namespace SweetAcademy.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>();
            this.Training = new HashSet<Training>();
        }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Training>? Training { get; set; }
    }
}
