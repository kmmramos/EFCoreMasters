namespace EFCoreAssignment.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public byte NumberOfStars { get; set; }
    }
}