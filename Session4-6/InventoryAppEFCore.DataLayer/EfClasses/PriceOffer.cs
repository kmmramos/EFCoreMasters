using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }

        public decimal NewPrice { get; set; }

        public string PromotinalText { get; set; }

        //relationship---
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
