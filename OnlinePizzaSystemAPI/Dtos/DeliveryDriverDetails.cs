namespace OnlinePizzaSystemAPI.Dtos
{
    public class DeliveryDriverDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string VehicleInformation { get; set; }
        public int? StoreId { get; set; } = null!;
    }
}
