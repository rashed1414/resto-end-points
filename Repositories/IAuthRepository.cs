using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantEndPoints.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Staff user, string password);
        Task<ServiceResponse<string>> LogIn (string email,string password);
        Task<bool> UserExists(string username);
    }
}