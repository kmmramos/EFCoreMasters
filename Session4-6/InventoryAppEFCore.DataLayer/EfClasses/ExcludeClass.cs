using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    [NotMapped]
    public class ExcludeClass
    {
        public const int NameLength = 50;
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }
    }
}
