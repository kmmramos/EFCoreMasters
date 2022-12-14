using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public short NumOfProducts { get; set; }
        public decimal ProductPrice { get; set; }

        //relationships
        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public Product SelectedProduct { get; set; }

    }
}
