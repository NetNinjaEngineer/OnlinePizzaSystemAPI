using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Dtos
{
    public class OrderItemDetailsDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string OrderItemName { get; set; }
        public int? OrderId { get; set; } = null!;
    }
}
