using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreAssignment.Data
{
    public class AppDbContextInitialiser
    {
        private readonly ILogger<AppDbContextInitialiser> logger;
        private readonly AppDbContext context;


        public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (this.context.Database.IsSqlServer())
                {
                    await this.context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while initializing the database.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await this.TrySeedAsync();
            }
            catch (Exception ex)
            {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while seeding the database.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!this.context.Shops.Any())
            {
                this.context.Shops.Add(new Shop()
                {
                    Name = "SM Online",
                });

                this.context.Shops.Add(new Shop()
                {
                    Name = "Zalora",
                });

                this.context.Shops.Add(new Shop()
                {
                    Name = "My Shop",
                });

                await this.context.SaveChangesAsync();
            }

            if (!this.context.Products.Any())
            {
                this.context.Products.Add(new Product()
                {
                    Name = "Floral Knee-Length Dress",
                    ShopId = 1
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Chuck Taylor All Start '70 Ox",
                    ShopId = 2
                });

                this.context.Products.Add(new Product()
                {
                    Name = "High-Waist 90s Fit Jeans",
                    ShopId = 3
                });

                await this.context.SaveChangesAsync();
            }

            if (!this.context.Reviews.Any())
            {
                this.context.Reviews.Add(new Review()
                {
                    ProductId = 1,
                    ReviewerName = "Reviewer One",
                    Comment = "The dress is too short even though the size is large.",
                    NumberOfStars = 2
                });

                this.context.Reviews.Add(new Review()
                {
                    ProductId = 2,
                    ReviewerName = "Reviewer Two",
                    Comment = "I love chuck taylor classic shoes!",
                    NumberOfStars = 5
                });

                this.context.Reviews.Add(new Review()
                {
                    ProductId = 3,
                    ReviewerName = "Reviewer Three",
                    Comment = "High quality clothing and looks expensive!",
                    NumberOfStars = 4
                });

                await this.context.SaveChangesAsync();
            }

            if (!this.context.Tags.Any())
            {
                this.context.Tags.Add(new Tag()
                {
                    Name = "Clothing"
                });

                this.context.Tags.Add(new Tag()
                {
                    Name = "Shoes"
                });

                this.context.Tags.Add(new Tag()
                {
                    Name = "Accesories"
                });

                await this.context.SaveChangesAsync();
            }
            
        }
    }
}
