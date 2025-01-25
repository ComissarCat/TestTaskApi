namespace TestTaskApi.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int ItemsCount { get; set; }
        public float ItemPrice { get; set; }
    }
}
