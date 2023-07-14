using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Dtos
{
    public class DeliveryDriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleInformation { get; set; }
        public string StoreName { get; set; }
        public int? StoreId { get; set; } = null!;
    }
}
