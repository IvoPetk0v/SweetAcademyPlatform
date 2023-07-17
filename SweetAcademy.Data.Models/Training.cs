using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SweetAcademy.Common.EntityValidationConstants.Training;

namespace SweetAcademy.Data.Models
{
    public class Training
    {
        public Training()
        {
            this.Participators = new HashSet<ApplicationUser>();
        }
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required] 
        public int OpenSeats { get; set; }

        [Required] 
        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))] 
        public virtual Recipe Recipe { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Participators { get; set; } = null!;

        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; } 
        [Required]
        public Guid ChefId { get; set; }

        [Required]
        [ForeignKey(nameof(ChefId))]
        public virtual Chef Trainer { get; set; }
    }
}