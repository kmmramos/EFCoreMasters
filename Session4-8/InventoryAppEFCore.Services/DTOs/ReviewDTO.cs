using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.Application.DTOs
{
    [AutoMap(typeof(Review))]
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public string VoterName { get; set; }

        public string Comment { get; set; }
        public int NumStars { get; set; }

        public int ProductId { get; set; }
    }
}
