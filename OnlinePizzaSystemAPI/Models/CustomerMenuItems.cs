namespace OnlinePizzaSystemAPI.Models
{
    public class CustomerMenuItems
    {
        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }

        public MenuItem MenuItem { get; set; }
        public Customer Customer { get; set; }
    }
}
