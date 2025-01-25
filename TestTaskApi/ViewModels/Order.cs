using TestTaskApi.Models;

namespace TestTaskApi.ViewModels
{
    public class Order
    {
        public Guid? Id { get; set; }
        public Customer? Customer { get; set; }
        public DateOnly? OrderDate { get; set; }
        public DateOnly? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public string? Status { get; set; }
    }
}
