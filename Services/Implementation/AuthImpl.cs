using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace OptiLoan.Services.Implementation
{
    public class AuthImpl : AuthService
    {
        public DataContext _Context;
        public AuthImpl(DataContext context)
        {
            _Context = context;
            
        }
        public Task<ServiceResponse<string>> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        // Register User
        public async Task<ServiceResponse<int>> Resgister(User user, string password)
        {
            // create response object
            var response = new ServiceResponse<int>();
            var hasNumber = new Regex(@"[0-9]+");
            var hasUperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbol = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]+");
           try{

            // check if user already exist in database
            if(await UserExist(user.Email)) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Password must contain number";
                return response;
            }

            // check if password contain number, characters(Upper_case & Lower_case) & Symbol
            if(!hasNumber.IsMatch(password)) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Password must contain number";
                return response;
            }else if(!hasUperChar.IsMatch(password)) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Password must contain Upper case";
                return response;
            }else if(!hasLowerChar.IsMatch(password)) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Password must contain Lower case";
                return response;
            }else if(!hasSymbol.IsMatch(password)) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Password must contain Symbol case";
                return response;
            }else{
            // Hash user password
            createHashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            }

            // add user to Users table
            _Context.Users.Add(user);
            // save database
            await _Context.SaveChangesAsync();
            // user response
            response.Data = user.Id;
            response.StatusCode = HttpStatusCode.Created;
            response.Message = "User Created";
            return response;

           }catch(Exception ex){
            response.Success = false;
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.Message = ex.Message;
            return response;
           }
        }

        public async Task<bool> UserExist(string email)
        {
            if(await _Context.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()))){
                return true;
            }

            return false;
        }

        // Hash User Password
        private void createHashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}