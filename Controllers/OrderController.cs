using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResturantEndPoints.Services.OrderService;
using Microsoft.AspNetCore.Mvc;
using ResturantEndPoints.DTO.OrderDTO;

namespace ResturantEndPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public async Task<ActionResult<ServiceResponse<List<GetOrderDTO>>>> GetOrders()
        {
            var serviceResponse = await _orderService.GetOrders();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> GetOrderById(int id)
        {
            var serviceResponse = await _orderService.GetOrderById(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("GetAllServicedOrder")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> GetAllServicedOrder()
        {
            var serviceResponse = await _orderService.GetAllServicedOrder();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> CreateOrder(AddOrderDTO order)
        {
            var serviceResponse = await _orderService.CreateOrder(order);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("UpdateOrder/{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> UpdateOrder(int id, AddOrderDTO order)
        {
            var serviceResponse = await _orderService.UpdateOrder(id, order);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<ActionResult<ServiceResponse<GetOrderDTO>>> DeleteOrder(int id)
        {
            var serviceResponse = await _orderService.DeleteOrder(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        
    }
}