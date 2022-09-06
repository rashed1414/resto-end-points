using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResturantEndPoints.Data;

namespace ResturantEndPoints.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly DataContext _context;

        public AuthRepository(DataContext context){
            _context = context;
        }
        public async Task<ServiceResponse<string>> LogIn(string email, string password)
        {
            var response = new ServiceResponse<string>();
            
        }

        public async Task<ServiceResponse<int>> Register(Staff user, string password)
        {
            var response = new ServiceResponse<int>();
            _context.Staffs.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
        
        private void CreatePasswordHash(string password) 
        {
            
        }
    }
}