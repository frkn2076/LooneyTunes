using Microsoft.EntityFrameworkCore;

namespace LooneyTunes.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        //DB Tables
        public DbSet<Cartoon> Cartoons { get; set; }

    }
}
