namespace OnlinePizzaSystemAPI.Models
{
    public class Coupon
    {
        public int Id { get; set; } 
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UsageLimit => UsageCount--;
        public int UsageCount { get; set; }
        public Customer Customer { get; set; } = null!;
        public int? CustomerId { get; set; } = null!;
    }
}
