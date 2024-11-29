using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) //calls the parent class constructor
        {
        }
        public DbSet<Activity> Activities { get; set; } //creates a table in the database
    }
}
