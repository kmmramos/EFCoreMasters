namespace EFCoreAssignment.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}