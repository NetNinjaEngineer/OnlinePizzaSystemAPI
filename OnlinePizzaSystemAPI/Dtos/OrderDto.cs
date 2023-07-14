using OnlinePizzaSystemAPI.Enums;

namespace OnlinePizzaSystemAPI.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeOnly OrderTime { get; set; }
        public decimal TotalCost { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }
        public int CustomerId { get; set; }
        public int DeliveryDriverId { get; set; }
    }
}
