using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Order
    {
        public Order()
        {
            DateOrderedUtc = DateTime.UtcNow;
        }

        public int OrderId { get; set; }

        public DateTime DateOrderedUtc { get; set; }

        //relationships
        public ICollection<LineItem> LineItems { get; set; }

        public OrderStatus Status { get; set; }

        public int ClientId { get; set; }
    }
}
