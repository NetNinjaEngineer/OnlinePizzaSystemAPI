namespace OnlinePizzaSystemAPI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<CustomerMenuItems> OrderMenuItems { get; set; } = new List<CustomerMenuItems>();
    }
}
