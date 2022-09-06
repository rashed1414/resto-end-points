using System;
using System.Collections.Generic;
using System.Linq;
using ResturantEndPoints.DTO.OrderDTO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResturantEndPoints.Data;

namespace ResturantEndPoints.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public OrderService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        
        public async Task<ServiceResponse<GetOrderDTO>> CreateOrder(AddOrderDTO order)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();
            try
            {
                var newOrder = _mapper.Map<Order>(order);
                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(newOrder);
                serviceResponse.Message = "Order Created";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDTO>> DeleteOrder(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);
                serviceResponse.Message = "Order Deleted";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDTO>> GetAllServicedOrder()
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();
            try
            {
                var orders = await _context.Orders.Where(o => o.IsServied == true).ToListAsync();
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(orders);
                serviceResponse.Message = "Order Fetched";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDTO>> GetOrderById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(order);
                serviceResponse.Message = "Order Fetched";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderDTO>>> GetOrders()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderDTO>>();
            try
            {
                var orders = await _context.Orders.ToListAsync();
                serviceResponse.Data = _mapper.Map<List<GetOrderDTO>>(orders);
                serviceResponse.Message = "Order Fetched";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDTO>> UpdateOrder(int id,AddOrderDTO order)
        {
            var serviceResponse = new ServiceResponse<GetOrderDTO>();
            try
            {
                var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
               
                orderToUpdate.IsServied = order.IsServied;
                orderToUpdate.IsTakeway = order.IsTakeway;
                orderToUpdate.TableNumber = order.TableNumber;

                _context.Orders.Update(orderToUpdate);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetOrderDTO>(orderToUpdate);
                serviceResponse.Message = "Order Updated";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;

        }
    }
}