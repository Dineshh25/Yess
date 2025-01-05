using Microsoft.EntityFrameworkCore;
using Yess.Models;

namespace Yess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    

    }

    
}
