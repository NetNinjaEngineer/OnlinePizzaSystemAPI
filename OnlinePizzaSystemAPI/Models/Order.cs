using OnlinePizzaSystemAPI.Enums;

namespace OnlinePizzaSystemAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeOnly OrderTime { get; set; }
        public decimal TotalCost { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public DeliveryDriver DeliveryDriver { get; set; }
        public int DeliveryDriverId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
