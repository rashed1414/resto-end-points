using System;
using System.Collections.Generic;
using System.Linq;
using ResturantEndPoints.DTO.OrderDTO;
using System.Threading.Tasks;

namespace ResturantEndPoints.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<GetOrderDTO>>> GetOrders();
        Task<ServiceResponse<GetOrderDTO>> GetOrderById(int id);
        Task<ServiceResponse<GetOrderDTO>> GetAllServicedOrder();
        Task<ServiceResponse<GetOrderDTO>> CreateOrder(AddOrderDTO order);
        Task<ServiceResponse<GetOrderDTO>> UpdateOrder(int id,AddOrderDTO order);
        Task<ServiceResponse<GetOrderDTO>> DeleteOrder(int id);
        
    }
}