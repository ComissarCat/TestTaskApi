using System.Data;

namespace TestTaskApi.Models
{
    public class OrderItem : DataSet
    {
        public Guid Id { get; set; }
        public Order OrderId { get; set; }
        public Item ItemId { get; set; }
        public int ItemsCount { get; set; }
        public float ItemPrice { get; set; }
    }
}
