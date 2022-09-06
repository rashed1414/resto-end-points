using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResturantEndPoints.Services.FoodService;
using Microsoft.AspNetCore.Mvc;

namespace ResturantEndPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("GetFoods")]
        public async Task<ActionResult<ServiceResponse<List<Food>>>> GetFoods()
        {
            var serviceResponse = await _foodService.GetFoods();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("GetFood/{id}")]
        public async Task<ActionResult<ServiceResponse<Food>>> GetFood(int id)
        {
            var serviceResponse = await _foodService.GetFood(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost("AddFood")]
        public async Task<ActionResult<ServiceResponse<Food>>> AddFood(Food food)
        {
            var serviceResponse = await _foodService.AddFood(food);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("UpdateFood/{id}")]
        public async Task<ActionResult<ServiceResponse<Food>>> UpdateFood(int id, Food food)
        {
            var serviceResponse = await _foodService.UpdateFood(id, food);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("DeleteFood/{id}")]
        public async Task<ActionResult<ServiceResponse<Food>>> DeleteFood(int id)
        {
            var serviceResponse = await _foodService.DeleteFood(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        
       
    }
}