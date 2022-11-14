// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = @"Server=.;Database=EFCoreMastersDB.Session01;Trusted_Connection=True"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

Filtering(dbContext);
SingleOrDefault(dbContext); 
LoadingRelatedData_Manual(dbContext);
LoadingRelatedData_ExplicitLoading(dbContext);
LoadingRelatedData_EagerLoading(dbContext);
InsertProduct(dbContext);
InsertProductWithNewShop(dbContext);
UpdateProduct(dbContext);
DeleteProduct(dbContext);
DeleteProductByKey(dbContext);

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name    
    var products = dbContext.Products
        .Where(a => a.Name == "Dell Laptop")
        .ToList();
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id    
    var products = dbContext.Products
        .SingleOrDefault(a => a.Id == 1);
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
    var product = dbContext.Products
        .FirstOrDefault();

    product.Shop = dbContext.Shops
        .Single(a => a.Id == product.Id);
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly
    var product = dbContext.Products
        .FirstOrDefault();

    dbContext.Entry(product)
        .Reference(b => b.Shop)
        .Load();
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related Shop data eagerly
    var product = dbContext.Products
        .Include(b => b.Shop)
        .FirstOrDefault();
}

static void InsertProduct(AppDbContext dbContext)
{
    // TODO: Insert a new Product
    var product = new Product
    {
        Name = "Apple Watch Ultra",
        ShopId = 1
    };
    dbContext.Products.Add(product);
    dbContext.SaveChanges();

    var products = dbContext.Products
        .Where(a => a.Name == "Apple Watch Ultra")
        .ToList();
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    // TODO: Insert a new Product with a new Shop
    var product = new Product
    {
        Name = "Samsung Galaxy Fold 4",
        Shop = new Shop
        {
            Name = "Mega Tech"
        }
    };
    dbContext.Products.Add(product);
    dbContext.SaveChanges();

    var products = dbContext.Products
        .Where(a => a.Name == "Samsung Galaxy Fold 4")
        .ToList();
}

static void UpdateProduct(AppDbContext dbContext)
{
    var products = dbContext.Products
        .Where(a => a.Id == 2)
        .ToList();

    // TODO: Update a Product
    var productId = 1;
    var product = dbContext.Products.Single(b => b.Id == 2);

    product.Name = "Apple Mouse Lightweight";
    dbContext.SaveChanges();

    var updateProducts = dbContext.Products
        .Where(a => a.Id == 2)
        .ToList();
}

static void DeleteProduct(AppDbContext dbContext)
{
    // TODO: Delete a Product
    var productId = 14;
    var product = dbContext.Products.Single(b => b.Id == productId);
    dbContext.Products.Remove(product);
    dbContext.SaveChanges();
}

static void DeleteProductByKey(AppDbContext dbContext)
{
    // TODO: Delete a Product with just having a key
    var productId = 13;
    var product = new Product { Id = productId };
    dbContext.Products.Remove(product);
    dbContext.SaveChanges();
}

Console.WriteLine("EF Core is the best");
