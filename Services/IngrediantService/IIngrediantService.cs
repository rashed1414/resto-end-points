using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ResturantEndPoints.Services.IngrediantService
{
    public interface IIngrediantService
    {
         Task<ServiceResponse<List<Ingrediant>>> GetAllIngrediant();
        Task<ServiceResponse<Ingrediant>> GetIngrdiant(int id);
        Task<ServiceResponse<Ingrediant>> AddIngrediant(Ingrediant ingrediant);
        Task<ServiceResponse<Ingrediant>> UpdateIngrediant(int id, Ingrediant ingrediant);
        Task<ServiceResponse<Ingrediant>> DeleteIngrediant(int id);
    }
}