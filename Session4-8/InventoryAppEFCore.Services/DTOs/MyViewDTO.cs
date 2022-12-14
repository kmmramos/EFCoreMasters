using AutoMapper;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.Application.DTOs
{
    [AutoMap(typeof(MyView))]
    public class MyViewDTO
    {
        public string VoterName { get; set; }
        public string Comment { get; set; }

        public int NumStars { get; set; }
    }
}
