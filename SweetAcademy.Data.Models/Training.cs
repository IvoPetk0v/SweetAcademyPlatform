using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using static SweetAcademy.Common.EntityValidationConstants;

namespace SweetAcademy.Data.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TrainingNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime EventDateTime { get; set; }

        [Required]
        public int OpenSeats { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; }=null!;

      public  ICollection<IdentityUser>
    }
}
