namespace ResturantEndPoints.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public string? FoodDescription { get; set; }
        public double? Price { get; set; }
        public FoodCategory foodCategory { get; set; }

        public List<Order>? Orders { get; set; }

        public List<Ingrediant> ingredients { get; set; }

    }
}
