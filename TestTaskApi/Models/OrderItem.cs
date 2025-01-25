namespace TestTaskApi.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int ItemsCount { get; set; }
        public float ItemPrice { get; set; }
        public void CalculateItemPrice(float price, float? discount)
        {
            if (discount is null)
                ItemPrice = price;
            else
                ItemPrice = price - price / 100 * discount.Value;
        }
    }
}
