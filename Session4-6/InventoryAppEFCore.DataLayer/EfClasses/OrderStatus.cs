using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public enum OrderStatus
    {
        None,
        Pending,
        InProgress,
        Complete,
        Cancelled
    }
}
