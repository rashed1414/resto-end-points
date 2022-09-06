using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantEndPoints.DTO.OrderDTO
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public bool IsTakeway { get; set; }
        public bool IsServied { get; set; }
        public DateTime OrderTime { get; set; }
        
    }
}