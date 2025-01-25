namespace TestTaskApi.ViewModels
{
    public class NewOrder
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
