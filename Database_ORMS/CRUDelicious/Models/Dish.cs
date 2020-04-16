using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [Display(Name = "Name of Dish")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Chef's Name")]
        public string Chef { get; set; }

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

        public Dish() { }
        public Dish(string name, string chef, int tastiness, int calories, string description)
        {
            Name = name;
            Chef = chef;
            Tastiness = tastiness;
            Calories = calories;
            Description = description;
        }

    }
}