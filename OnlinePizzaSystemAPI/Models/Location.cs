namespace OnlinePizzaSystemAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
