namespace ResturantEndPoints.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public bool IsTakeway { get; set; }
        public bool IsServied { get; set; }
        public DateTime OrderTime { get; set; }=DateTime.Now;
        public List<Food> FoodList { get; set; }
    }
}
