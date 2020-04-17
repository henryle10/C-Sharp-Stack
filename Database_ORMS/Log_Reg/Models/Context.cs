using Microsoft.EntityFrameworkCore;

namespace Log_Reg.Models
{
    public class LoginContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LoginContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}