using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.EfClasses;
using System.Collections.Generic;

namespace InventoryAppEFCore.Application
{
    public static class EFTestData
    {
        public static List<Product> SeedDatabase(this InventoryAppEfCoreContext context)
        {
            var products = CreateProducts();
            context.Products.AddRange(products);
            context.SaveChanges();
            return products;
        }

        public static List<Product> CreateProducts()
        {
            var clothesTag = new Tag { TagId = "Clothes" };
            var shoesTag = new Tag { TagId = "Shoes" };

            var supplier1 = new Supplier
            {
                Name = "SM Department Store",
                Description = "A large department store"
            };

            var priceOffer1 = new PriceOffer
            {
                NewPrice = 100,
                PromotinalText = "Christmas Promo"
            };

            var products = new List<Product>();

            var product1 = new Product
            {
                Name = "White Dress",
                Promotion = priceOffer1,
                Tags = new List<Tag> { clothesTag },
                SuppliersLink = new List<Supplier> { supplier1 },
                IsDeleted = false,
            };
            product1.Reviews = new List<Review>
            {
                new Review
                {
                    VoterName = "Voter1", NumStars = 5,
                    Comment = "I look forward to wearing this white dress!"
                },
                new Review
                {
                    VoterName = "Voter2", NumStars = 5, Comment = "It's worthy of its price!"
                }
            };
            products.Add(product1);

            var product2 = new Product
            {
                Name = "White Shoes",
                Promotion = priceOffer1,
                Tags = new List<Tag> { shoesTag },
                SuppliersLink = new List<Supplier> { supplier1 },
                IsDeleted = false,
            };
            product2.Reviews = new List<Review>
            {
                new Review
                {
                    VoterName = "Voter1", NumStars = 3,
                    Comment = "Shoes is too small!"
                },
                new Review
                {
                    VoterName = "Voter2", NumStars = 5, Comment = "It looks sturdy!"
                }
            };
            products.Add(product2);

            var product3 = new Product
            {
                Name = "Khaki Dress",
                Promotion = priceOffer1,
                Tags = new List<Tag> { clothesTag },
                SuppliersLink = new List<Supplier> { supplier1 },
                IsDeleted = false,
            };
            product3.Reviews = new List<Review>
            {
                new Review
                {
                    VoterName = "Voter1", NumStars = 4,
                    Comment = "One of a kind!"
                },
                new Review
                {
                    VoterName = "Voter2", NumStars = 5, Comment = "Looks expensive for its price!"
                }
            };
            products.Add(product3);

            return products;
        }
    }
}
