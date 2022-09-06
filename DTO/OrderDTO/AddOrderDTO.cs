using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantEndPoints.DTO.OrderDTO
{
    public class AddOrderDTO
    {
        public int TableNumber { get; set; }
        public bool IsTakeway { get; set; }
        public bool IsServied { get; set; }
    }
}