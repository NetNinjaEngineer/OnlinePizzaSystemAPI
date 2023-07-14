using OnlinePizzaSystemAPI.Enums;

namespace OnlinePizzaSystemAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Position Position { get; set; }

        public Location Location { get; set; } = null!;
        public int? LocationId { get; set; } = null!;
    }
}
