namespace OnlinePizzaSystemAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public int SupplierId { get; set; }
        public int? InventoryId { get; set; } = null!;
    }
}
