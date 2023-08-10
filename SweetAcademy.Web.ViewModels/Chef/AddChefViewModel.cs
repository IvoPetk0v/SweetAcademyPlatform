using System.ComponentModel.DataAnnotations;

using SweetAcademy.Web.ViewModels.User;
using static SweetAcademy.Common.EntityValidationConstants.Chef;

namespace SweetAcademy.Web.ViewModels.Chef
{
    public class AddChefViewModel
    {
        public AddChefViewModel()
        {
            this.Users = new HashSet<UserViewModel>();
        }
        
        [Required]
        public Guid ApplicationUserId { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(FullNameMaxLength,MinimumLength = FullNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [Range(TaxPerTrainingForStudentMinValue,TaxPerTrainingForStudentMaxValue)]
        public decimal TaxPerTrainingForStudent { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public ICollection<UserViewModel> Users { get; set; } 
    }
}
