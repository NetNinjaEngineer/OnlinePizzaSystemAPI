using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? OrderId { get; set; } = null!;
    }
}
