namespace OnlinePizzaSystemAPI.Dtos
{
    public class IngredientDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int? InventoryId { get; set; } = null!;
    }
}
