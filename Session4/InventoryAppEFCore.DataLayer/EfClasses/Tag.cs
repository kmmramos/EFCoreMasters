using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
  
    public class Tag
    {
        [Key]
        [Required]
        public string TagId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
