using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SweetAcademy.Common.EntityValidationConstants.Chef;

namespace SweetAcademy.Data.Models
{
    public class Chef
    {
        public Chef()
        {
                this.CouchingSession=new HashSet<Training>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ApplicationUserId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public decimal TaxPerTrainingForStudent { get; set; }

        public virtual ICollection<Training> CouchingSession { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; } 
    }
}
