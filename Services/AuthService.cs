using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OptiLoan.Services
{
    public interface AuthService
    {
        Task<ServiceResponse<int>> Resgister(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExist(string email);
    }
}