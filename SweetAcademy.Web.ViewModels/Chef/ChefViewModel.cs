using System.ComponentModel.DataAnnotations;
using SweetAcademy.Data.Models;
using static SweetAcademy.Common.EntityValidationConstants.Chef;
namespace SweetAcademy.Web.ViewModels.Chef
{
    public class ChefViewModel
    {
        public ChefViewModel()
        {
            this.CouchingSession = new HashSet<Training>();
        }

        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }

        public ApplicationUser? User { get; set; } 
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [StringLength(FullNameMaxLength,MinimumLength = FullNameMinLength)]
        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        [Required]
        [Range(TaxPerTrainingForStudentMinValue,TaxPerTrainingForStudentMaxValue)]
        public decimal TaxPerTrainingForStudent { get; set; }

        public virtual ICollection<Training>? CouchingSession { get; set; }

      
        public bool Active { get; set; }

    }
}
