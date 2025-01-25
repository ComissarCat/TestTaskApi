using System.Data;

namespace TestTaskApi.Models
{
    public class Order : DataSet
    {
        public Guid Id { get; set; }
        public Customer CustomerId { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public string? Status { get; set; }
    }
}
