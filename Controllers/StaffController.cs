using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ResturantEndPoints.Services.StaffService;
using Microsoft.AspNetCore.Mvc;

namespace ResturantEndPoints.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {

        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("GetStaffs")]
        public async Task<ActionResult<ServiceResponse<List<Staff>>>> GetStaffs()
        {
            var serviceResponse = await _staffService.GetStaffs();
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpGet("GetStaffById/{id}")]
        public async Task<ActionResult<ServiceResponse<Staff>>> GetStaffById(int id)
        {
            var serviceResponse = await _staffService.GetStaffById(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpGet("GetStaffByRole/{role}")]
        public async Task<ActionResult<ServiceResponse<Staff>>> GetStaffByRole(Role role)
        {
            var serviceResponse = await _staffService.GetStaffsByRole(role);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPost("AddStaff")]
        public async Task<ActionResult<ServiceResponse<Staff>>> AddStaff(Staff staff)
        {
            var serviceResponse = await _staffService.AddStaff(staff);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("UpdateStaff")]
        public async Task<ActionResult<ServiceResponse<Staff>>> UpdateStaff(Staff staff)
        {
            var serviceResponse = await _staffService.UpdateEmployee(staff);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("DeleteStaff/{id}")]
        public async Task<ActionResult<ServiceResponse<Staff>>> DeleteStaff(int id)
        {
            var serviceResponse = await _staffService.DeleteStaff(id);
            if (serviceResponse.Success == false)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }





    }
}