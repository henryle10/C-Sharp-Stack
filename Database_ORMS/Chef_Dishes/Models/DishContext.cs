using Microsoft.EntityFrameworkCore;

namespace Chef_Dishes.Models
{
    public class DishContext : DbContext
    {
        public DishContext(DbContextOptions options) : base(options) { }
        // tables in db
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Chef> Chefs { get; set; }
    }
}