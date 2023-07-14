namespace OnlinePizzaSystemAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; } = null!;
        public int? OrderId { get; set; } = null!;
    }
}
