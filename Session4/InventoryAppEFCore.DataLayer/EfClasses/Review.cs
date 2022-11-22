using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Review
    {
        public const int NameLength = 50;
        public int ReviewId { get; set; }

        [MaxLength(NameLength)]
        public string VoterName { get; set; }

        public string Comment { get; set; }
        public int NumStars { get; set; }

        public int ProductId { get; set; }
    }
}
