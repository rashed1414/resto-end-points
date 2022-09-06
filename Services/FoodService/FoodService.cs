using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ResturantEndPoints.Data;
using Microsoft.EntityFrameworkCore;

namespace ResturantEndPoints.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public FoodService(IMapper mapper ,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<ServiceResponse<Food>> AddFood(Food food)
        {
            var serviceResponse = new ServiceResponse<Food>();
            try
            {
                await _context.Foods.AddAsync(food);
                await _context.SaveChangesAsync();
                serviceResponse.Data = food;
                serviceResponse.Message = "Food Added";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Food>> DeleteFood(int id)
        {
            var serviceResponse = new ServiceResponse<Food>();
            try
            {
                var food = await _context.Foods.FirstOrDefaultAsync(f => f.Id == id);
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
                serviceResponse.Data = food;
                serviceResponse.Message = "Food Deleted";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Food>> GetFood(int id)
        {
            var serviceResponse = new ServiceResponse<Food>();
            var food = await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<Food>(food);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Food>>> GetFoods()
        {
            var serviceResponse = new ServiceResponse<List<Food>>();
            var foods = await _context.Foods.ToListAsync();
            serviceResponse.Data = foods.Select(f => _mapper.Map<Food>(f)).ToList();
            return serviceResponse;
        }



        public async Task<ServiceResponse<Food>> UpdateFood(int id,Food food)
        {
            var serviceResponse = new ServiceResponse<Food>();
            try
            {
                var dbFood = await _context.Foods.FirstOrDefaultAsync(x => x.Id == id);
                dbFood.FoodName = food.FoodName;
                dbFood.Price = food.Price;
                dbFood.FoodDescription = food.FoodDescription;
                dbFood.foodCategory = food.foodCategory;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<Food>(dbFood);
                serviceResponse.Message = "Food Updated";
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