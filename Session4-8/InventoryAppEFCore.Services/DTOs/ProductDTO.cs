using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.Application.DTOs
{
    [AutoMap(typeof(Product))]
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        //relationships---
        public PriceOfferDTO Promotion { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
        public ICollection<TagDTO> Tags { get; set; }

        public ICollection<SupplierDTO> SuppliersLink { get; set; }

        public bool IsDeleted { get; set; }
    }
}
