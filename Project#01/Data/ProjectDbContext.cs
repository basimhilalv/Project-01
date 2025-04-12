using Microsoft.EntityFrameworkCore;
using Project_01.Models;

namespace Project_01.Data
{
    public class ProjectDbContext : DbContext
    {
         public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
