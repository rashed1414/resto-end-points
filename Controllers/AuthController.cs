using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResturantEndPoints.DTO.StaffDTO;
using ResturantEndPoints.Repositories;

namespace ResturantEndPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository){
            _authRepository = authRepository;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(StaffResgisterDTO request){
            var response = await _authRepository.Register(
                new Staff{
                    Email = request.Email,
                }, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(StaffLoginDTO request){
            var response = await _authRepository.LogIn(request.Email, request.Password);
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}