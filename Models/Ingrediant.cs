using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantEndPoints.Models
{
    public class Ingrediant
    {
        public int Id { get; set; }
        public string? ingrediantName { get; set; }
        public List<Food> Foods { get; set; }
        
}
}