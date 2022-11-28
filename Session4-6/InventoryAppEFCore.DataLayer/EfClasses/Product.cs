using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        //relationships---
        public PriceOffer Promotion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public ICollection<Supplier> SuppliersLink { get; set; }

        public bool IsDeleted { get; set; }
    }
}
