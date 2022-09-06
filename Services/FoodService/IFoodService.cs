using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantEndPoints.Services.FoodService
{
    public interface IFoodService
    {
        Task<ServiceResponse<List<Food>>> GetFoods();
        Task<ServiceResponse<Food>> GetFood(int id);
        Task<ServiceResponse<Food>> AddFood(Food food);
        Task<ServiceResponse<Food>> UpdateFood(int id,Food food);
        Task<ServiceResponse<Food>> DeleteFood(int id);
        
    }
}