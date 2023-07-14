namespace OnlinePizzaSystemAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public ICollection<Topping> Toppings { get; set; } = new List<Topping>();
    }
}
