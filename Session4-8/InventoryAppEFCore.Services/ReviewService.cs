using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.Application.DTOs;
using InventoryAppEFCore.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InventoryAppEFCore.Application
{
    public class ReviewService : IReviewService
    {
        private readonly InventoryAppEfCoreContext _context;
        public ReviewService(InventoryAppEfCoreContext context)
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

        public async Task<List<MyViewDTO>> GetAllReviews()
        {
            var config = CreateMapperConfigScanTestAutoMap();

            var myViewDTO = await _context.MyViews
                .ProjectTo<MyViewDTO>(config).ToListAsync();

            return myViewDTO;
        }
    }

    public interface IReviewService
    {
        Task<List<MyViewDTO>> GetAllReviews();
    }
}
