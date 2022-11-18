using EFCoreAssignment.Data.Entities;
using EFCoreAssignment.Services.Exceptions;
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
            if (!ShopExists(productForCreation.ShopId))
                throw new NotFoundException("Shop is not found!");

            var product = new Product()
            {
                Name = productForCreation.Name,
                ShopId = productForCreation.ShopId
            };            

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            int createdProductId = GetProduct(product.Id).Result.Id;
            return createdProductId;
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            if (!ProductExists(productForUpdate.Id))
                throw new NotFoundException("Product is not found!");
            else if (!ShopExists(productForUpdate.ShopId))
                throw new NotFoundException("Shop is not found!");

            var product = new Product()
            {
                Id = productForUpdate.Id,
                Name = productForUpdate.Name,
                ShopId = productForUpdate.ShopId
            };

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var productToBeDeleted = await _context.Products.FindAsync(id);
            if (productToBeDeleted == null)
                throw new NotFoundException("Product is not found!");

            _context.Products.Remove(productToBeDeleted);
            await _context.SaveChangesAsync();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private bool ShopExists(int id)
        {
            return _context.Shops.Any(e => e.Id == id);
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