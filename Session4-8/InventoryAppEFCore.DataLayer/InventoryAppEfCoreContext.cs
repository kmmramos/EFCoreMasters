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
        public DbSet<MyView> MyViews { get; set; }
        public virtual DbSet<MyUdfMethods> MyUdfMethods { get; set; }


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

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    TagId = "Clothes"                    
                }
            );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    SupplierId = 1,
                    Name = "SM Department Store",
                    Description = "A large department store"
                }
            );

            modelBuilder.Entity<PriceOffer>().HasData(
                new PriceOffer
                {
                    PriceOfferId = 1,
                    NewPrice = 100,
                    PromotinalText = "Christmas Promo",
                    ProductId = 1,
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "White Dress",
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = 1,
                    VoterName = "Voter Name 1",
                    Comment = "The dress looks flowy!",
                    NumStars = 4,
                    ProductId = 1,
                }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = 2,
                    VoterName = "Voter Name 2",
                    Comment = "The dress is too big!",
                    NumStars = 5,
                    ProductId = 1,
                }
            );

            modelBuilder.Entity<MyView>().ToView("EntityFilterView").HasNoKey();

            modelBuilder.Entity<MyUdfMethods>(e => e.HasNoKey());
        }

    }
}