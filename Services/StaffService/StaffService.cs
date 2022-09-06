using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResturantEndPoints.Data;

namespace ResturantEndPoints.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public StaffService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<Staff>> AddStaff(Staff staff)
        {
            var serviceResponse = new ServiceResponse<Staff>();
            try
            {
                await _context.Staffs.AddAsync(staff);
                await _context.SaveChangesAsync();
                serviceResponse.Data = staff;
                serviceResponse.Message = "Staff Added";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Staff>> DeleteStaff(int id)
        {
            var serviceResponse = new ServiceResponse<Staff>();
            try
            {
                var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
                serviceResponse.Data = staff;
                serviceResponse.Message = "Staff Deleted";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Staff>> GetStaffById(int id)
        {
            var serviceResponse = new ServiceResponse<Staff>();
            try
            {
                var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
                serviceResponse.Data = staff;
                serviceResponse.Message = "Staff Found";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Staff>>> GetStaffs()
        {
            var serviceResponse = new ServiceResponse<List<Staff>>();
            try
            {
                var staffs = await _context.Staffs.ToListAsync();
                serviceResponse.Data = staffs;
                serviceResponse.Message = "Staffs Found";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Staff>>> GetStaffsByRole(Role staffRole)
        {
            var serviceResponse = new ServiceResponse<List<Staff>>();
            try
            {
                var staffs = await _context.Staffs.Where(s => s.role == staffRole).ToListAsync();
                serviceResponse.Data = staffs;
                serviceResponse.Message = "Staffs Found";
                serviceResponse.Success = true;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        

        public async Task<ServiceResponse<Staff>> UpdateEmployee(Staff staff)
        {
            var serviceResponse = new ServiceResponse<Staff>();
            try
            {
                var staffToUpdate = await _context.Staffs.FirstOrDefaultAsync(s => s.Id == staff.Id);
                staffToUpdate.Name = staff.Name;
                staffToUpdate.role = staff.role;
                staffToUpdate.Salary = staff.Salary;
                staffToUpdate.Email = staff.Email;
                staffToUpdate.Number = staff.Number;
                staffToUpdate.Adress = staff.Adress;
                staffToUpdate.PasswordHash = staff.PasswordHash;
                staffToUpdate.PasswordSalt = staff.PasswordSalt;
                await _context.SaveChangesAsync();
                serviceResponse.Data = staffToUpdate;
                serviceResponse.Message = "Staff Updated";
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