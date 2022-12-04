using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.Application.DTOs
{
    [AutoMap(typeof(PriceOffer))]
    public class PriceOfferDTO
    {
        public int PriceOfferId { get; set; }

        public decimal NewPrice { get; set; }

        public string PromotinalText { get; set; }

        //relationship---
        public int ProductId { get; set; }
    }
}
