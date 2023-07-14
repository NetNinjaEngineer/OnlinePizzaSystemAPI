namespace OnlinePizzaSystemAPI.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreManager { get; set; }
        public ICollection<DeliveryDriver> DeliveryDrivers { get; set; } = new List<DeliveryDriver>();
    }
}
