namespace OnlinePizzaSystemAPI.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AdditionalCost { get; set; }

        public Pizza? Pizza { get; set; } 
        public int? PizzaId { get; set; }
    }
}
