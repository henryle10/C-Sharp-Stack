using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chef_Dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public int age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [BirthdayValidator]
        public DateTime DOB { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> CreatedDishes { get; set; }

    }
    public class BirthdayValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthday = Convert.ToDateTime(value);
            DateTime today = DateTime.Now;
            var age = today.Year - birthday.Year;
            if (birthday > today)
            {
                return new ValidationResult("Not a valid birthday");
            }
            else if (age < 18)
            {
                return new ValidationResult("Must be at least 18 years old");
            }
            return ValidationResult.Success;
        }
    }
}