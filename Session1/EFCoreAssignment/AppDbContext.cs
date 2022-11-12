using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shop> Shops { get; set; }

    }
}
