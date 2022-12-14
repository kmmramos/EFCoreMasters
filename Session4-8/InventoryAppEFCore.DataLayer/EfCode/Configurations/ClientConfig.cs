using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InventoryAppEFCore.DataLayer.EfCode.Configurations
{
    internal class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure
            (EntityTypeBuilder<Client> entity)
        {
            entity.HasKey(t => t.ClientId);
            entity.Property<DateTime>("UpdatedOn");
        }
    }
}
