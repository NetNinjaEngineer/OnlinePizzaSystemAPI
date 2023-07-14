using OnlinePizzaSystemAPI.Enums;

namespace OnlinePizzaSystemAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public Customer Customer { get; set; } = null!;
        public int? CustomerId { get; set; } = null!;
    }
}
