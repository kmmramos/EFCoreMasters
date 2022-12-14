using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Client
    {
        public const int NameLength = 50;

        private int _clientId;

        [BackingField(nameof(_clientId))]
        public int ClientId
        {
            get { return _clientId; }
        }

        public void SetCliendIdValue(int value)
        {
            _clientId = value;
        }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

    }
}
