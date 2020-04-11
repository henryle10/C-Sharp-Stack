namespace Dojo_Survey.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
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