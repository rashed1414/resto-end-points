using System.Text.Json.Serialization;

namespace ResturantEndPoints.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FoodCategory
    {
        MainCourses = 0,
        Desserts = 1,
        Drinks = 2,
        Appetizers = 3,
        Salads = 4,
        Soups = 5,
        SideDishes = 6
        
    }
}