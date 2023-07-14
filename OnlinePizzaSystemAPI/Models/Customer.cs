namespace OnlinePizzaSystemAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Coupon Coupon { get; set; } = null!;

        public Payment Payment { get; set; } = null!;

        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public ICollection<CustomerMenuItems> OrderMenuItems { get; set; } = new List<CustomerMenuItems>();

    }
}
