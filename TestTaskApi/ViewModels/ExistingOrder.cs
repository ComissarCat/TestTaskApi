using TestTaskApi.Models;

namespace TestTaskApi.ViewModels
{
    public class ExistingOrder
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public DateOnly? ShipmentDate { get; set; }
    }
}
