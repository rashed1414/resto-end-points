using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResturantEndPoints.Services.IngrediantService;

namespace ResturantEndPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngrediantController : ControllerBase
    {
        private readonly IIngrediantService _ingrediantService;
        public IngrediantController(IIngrediantService ingrediantService)
        {
            _ingrediantService = ingrediantService;
        }

        [HttpGet("GetAllIngrediants")]
        public async Task<ActionResult<ServiceResponse<List<Ingrediant>>>> GetAllIngrediants()
        {
            return Ok(await _ingrediantService.GetAllIngrediant());
        }

        [HttpGet("GetIngrediant/{id}")]
        public async Task<ActionResult<ServiceResponse<Ingrediant>>> GetIngrediant(int id)
        {
            return Ok(await _ingrediantService.GetIngrdiant(id));
        }

        [HttpPost("AddIngrediant")]
        public async Task<ActionResult<ServiceResponse<Ingrediant>>> AddIngrediant(Ingrediant ingrediant)
        {
            return Ok(await _ingrediantService.AddIngrediant(ingrediant));
        }

        [HttpDelete("DeleteIngrediant/{id}")]
        public async Task<ActionResult<ServiceResponse<Ingrediant>>> DeleteIngrediant(int id)
        {
            return Ok(await _ingrediantService.DeleteIngrediant(id));
        }
        
        [HttpPut("UpdateIngrediant")]
        public async Task<ActionResult<ServiceResponse<Ingrediant>>> UpdateIngrediant(int id , Ingrediant ingrediant)
        {
            return Ok(await _ingrediantService.UpdateIngrediant(id,ingrediant));
        }

        





        
    }
}