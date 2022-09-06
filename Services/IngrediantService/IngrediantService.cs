using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResturantEndPoints.Data;

namespace ResturantEndPoints.Services.IngrediantService
{
    public class IngrediantService:IIngrediantService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public IngrediantService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<Ingrediant>> AddIngrediant(Ingrediant ingrediant)
        {
            var serviceResponse=new ServiceResponse<Ingrediant>();
             try
            {
                await _context.Ingrediants.AddAsync(ingrediant);
                await _context.SaveChangesAsync();
                serviceResponse.Data = ingrediant;
                serviceResponse.Message = "ingrediant Added";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
           
        }

        public async Task<ServiceResponse<Ingrediant>> DeleteIngrediant(int id)
        {
            var serviceResponse = new ServiceResponse<Ingrediant>();
            try
            {
                var ingrediant = await _context.Ingrediants.FirstOrDefaultAsync(f => f.Id == id);
                _context.Ingrediants.Remove(ingrediant);
                await _context.SaveChangesAsync();
                serviceResponse.Data = ingrediant;
                serviceResponse.Message = "ingrediant Deleted";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Ingrediant>>> GetAllIngrediant()
        {
            var serviceResponse = new ServiceResponse<List<Ingrediant>>();
            var dbIngrediants = await _context.Ingrediants.ToListAsync();
            serviceResponse.Data = dbIngrediants;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Ingrediant>> GetIngrdiant(int id)
        {
            var serviceResponse = new ServiceResponse<Ingrediant>();
            try
            {
                var dbIngrediant = await _context.Ingrediants.FirstOrDefaultAsync(f => f.Id == id);
                serviceResponse.Data = dbIngrediant;
                serviceResponse.Message = "ingrediant Found";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<Ingrediant>> UpdateIngrediant(int id, Ingrediant ingrediant)
        {
            var serviceResponse = new ServiceResponse<Ingrediant>();
            try
            {
                var dbIngrediant = await _context.Ingrediants.FirstOrDefaultAsync(f => f.Id == id);
                dbIngrediant.ingrediantName = ingrediant.ingrediantName;
                await _context.SaveChangesAsync();
                serviceResponse.Data = dbIngrediant;
                serviceResponse.Message = "ingrediant Updated";
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