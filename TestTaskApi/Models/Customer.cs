namespace TestTaskApi.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Address { get; set; }
        public float? Discount { get; set; }
    }
}
