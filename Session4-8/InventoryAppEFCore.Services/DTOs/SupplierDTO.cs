using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.Application.DTOs
{
    [AutoMap(typeof(Supplier))]
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //Relationships
        public ICollection<ProductDTO> ProductsLink { get; set; }
    }
}
