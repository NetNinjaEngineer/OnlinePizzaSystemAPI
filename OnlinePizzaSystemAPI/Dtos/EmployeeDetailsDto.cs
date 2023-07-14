using OnlinePizzaSystemAPI.Enums;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Dtos
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Position Position { get; set; }
        public string LocationName { get; set; } = null!;
        public int? LocationId { get; set; } = null!;
    }
}
