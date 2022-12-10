using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.Application.DTOs;
using InventoryAppEFCore.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InventoryAppEFCore.Application
{
    public class ProductService : IProductService
    {
        private readonly InventoryAppEfCoreContext _context;
        public ProductService(InventoryAppEfCoreContext context)
        {
            _context = context;
        }

        public static MapperConfiguration CreateMapperConfig<TSource, TDestination>()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
        }

        public static MapperConfiguration CreateMapperConfigScanTestAutoMap()
        {
            return new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var config = CreateMapperConfigScanTestAutoMap();

            var productDto = await _context.Products
                .Include(v => v.Promotion)
                .Include(v => v.Reviews)
                .Include(v => v.SuppliersLink)
                .Include(v => v.Tags)
                .ProjectTo<ProductDTO>(config).ToListAsync();

            return productDto;
        }

        public async Task<List<ProductDTO>> GetNonDeletedProducts()
        {
            _context.Database.EnsureCreated();
            var productCreated = _context.SeedDatabase();
            var config = CreateMapperConfigScanTestAutoMap();

            productCreated[2].IsDeleted = true;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            var productDto = await _context.Products
                .Include(v => v.Promotion)
                .Include(v => v.Reviews)
                .Include(v => v.SuppliersLink)
                .Include(v => v.Tags)
                .ProjectTo<ProductDTO>(config).ToListAsync();

            return productDto;
        }
    }

    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<List<ProductDTO>> GetNonDeletedProducts();
    }
}