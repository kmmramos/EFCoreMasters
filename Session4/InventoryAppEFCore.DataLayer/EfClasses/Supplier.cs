using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Supplier
    {
        public const int NameLength = 50;
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public ExcludeClass ExcludedClass { get; set; }

        //Relationships
        public ICollection<Product> ProductsLink { get; set; }
    }
}
