using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chef_Dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public int ChefId { get; set; }

        [Required]
        [Display(Name = "Name of Dish")]
        public string Name { get; set; }

        [Required]
        [Range(0, 6)]
        public int Tastiness { get; set; }

        [Required]
        [Range(0, 10000)]
        [Display(Name = "# of Calories")]
        public int Calories { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Chef Creator { get; set; }
    }
}