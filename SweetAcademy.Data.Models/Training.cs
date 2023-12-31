﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static SweetAcademy.Common.EntityValidationConstants.TrainingValidation;

namespace SweetAcademy.Data.Models
{
    public class Training
    {
        public Training()
        {
            this.Orders = new HashSet<Order>();
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
        public virtual ICollection<Order> Orders { get; set; } =null!;

        [Required]
        public bool Active { get; set; } 

        [Required]
        public Guid ChefId { get; set; }

        [Required]
        [ForeignKey(nameof(ChefId))]
        public virtual Chef Trainer { get; set; }=null!;
    }
}