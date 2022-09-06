using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantEndPoints.Services.StaffService
{
    public interface IStaffService
    {
        Task<ServiceResponse<Staff>> GetStaffById(int id);
        Task<ServiceResponse<List<Staff>>> GetStaffs();
        Task<ServiceResponse<List<Staff>>> GetStaffsByRole(Role staffRole);
        Task<ServiceResponse<Staff>> AddStaff(Staff staff);
        Task<ServiceResponse<Staff>> UpdateEmployee(Staff staff);
        Task<ServiceResponse<Staff>> DeleteStaff(int id);
        
    }
}