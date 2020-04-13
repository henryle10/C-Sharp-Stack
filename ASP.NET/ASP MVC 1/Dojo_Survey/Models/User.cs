using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Language { get; set; }
        [MaxLength(20)]
        public string Comment { get; set; }
        public User() { }
        public User(string firstName, string location, string language, string comment)
        {
            FirstName = firstName;
            Location = location;
            Language = language;
            Comment = comment;
        }
    }
}