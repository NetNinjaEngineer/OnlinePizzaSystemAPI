namespace OnlinePizzaSystemAPI.Models
{
    public class DeliveryDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleInformation { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Store Store { get; set; } = null!;
        public int? StoreId { get; set; } = null!;
    }
}
