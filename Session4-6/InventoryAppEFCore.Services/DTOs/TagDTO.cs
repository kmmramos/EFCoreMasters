using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.Application.DTOs
{
    [AutoMap(typeof(Tag))]
    public class TagDTO
    {
        public string TagId { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
    }
}
