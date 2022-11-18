using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            var productDto = await _context.Products.Select(i => new ProductDto(i.Id, i.Name, i.ShopId)).ToListAsync();

            if (productDto == null)
                return null;

            return productDto;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return null;

            var productDto = new ProductDto(product.Id, product.Name, product.ShopId);
            return productDto;
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            var product = new Product()
            {
                Name = productForCreation.Name,
                ShopId = productForCreation.ShopId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            int createdProductId = GetProduct(product.Id).Result.Id;
            if (createdProductId == 0)
                return 0;

            return createdProductId;
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            var product = new Product()
            {
                Id = productForUpdate.Id,
                Name = productForUpdate.Name,
                ShopId = productForUpdate.ShopId
            };
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!ProductExists(productForUpdate.Id))
                    throw new DbUpdateConcurrencyException();
                else
                    throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var productToBeDeleted = await _context.Products.FindAsync(id);
            if (productToBeDeleted == null)
                throw new ArgumentNullException("Product is not found!");

            _context.Products.Remove(productToBeDeleted);
            await _context.SaveChangesAsync();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}