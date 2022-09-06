using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ResturantEndPoints.DTO.OrderDTO;

namespace ResturantEndPoints
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, GetOrderDTO>();
            CreateMap<AddOrderDTO, Order>();
            
        }
        
    }
}