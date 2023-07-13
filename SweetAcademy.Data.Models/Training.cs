using System.ComponentModel.DataAnnotations;
using static SweetAcademy.Common.EntityValidationConstants;

namespace SweetAcademy.Data.Models
{
    public  class Training
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [MaxLength(TrainingNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
