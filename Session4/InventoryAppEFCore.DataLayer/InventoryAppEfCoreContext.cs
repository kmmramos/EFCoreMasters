using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {
      
        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //TO DO Fluent API
            var utcConverter = new ValueConverter<DateTime, DateTime>(
                toDb => toDb,
                fromDb =>
                    DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entityProperty in entityType.GetProperties())
                {
                    if (entityProperty.ClrType == typeof(DateTime)
                        && entityProperty.Name.EndsWith("Utc"))
                    {
                        entityProperty.SetValueConverter(utcConverter);
                    }

                    if (entityProperty.ClrType == typeof(decimal)
                        && entityProperty.Name.Contains("Price"))
                    {
                        entityProperty.SetPrecision(9);
                        entityProperty.SetScale(2);
                    }
                }
            }
        }

    }
}