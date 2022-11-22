using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class ProductSupplier
    {
        [Key]
        [Column(Order = 0)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int SupplierId { get; set; }

        public byte Order { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
