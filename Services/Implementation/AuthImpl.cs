using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

using System.Threading.Tasks;


namespace OptiLoan.Services.Implementation
{
    public class AuthImpl : AuthService
    {
        public DataContext _Context;
        private readonly IConfiguration _configuration;
        public AuthImpl(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _Context = context;
            
        }

        // Login User
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            // create response object
            var response = new ServiceResponse<string>();
            
            try{
                // check if user exist
                var user = await _Context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));
                if(user is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid Credentials";
                    return response;
                }else if(!comparePassword(password, user.PasswordHash, user.PasswordSalt)){ //compare password
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid Credentials";
                    return response;
                }else{
                    response.Data = createToken(user);
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "User Login";
                    return response;
                }
            }catch(Exception ex){

                response.Success = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        // Register User
        public async Task<ServiceResponse<string>> Resgister(User user, string password)
        {
            // create response object
            var response = new ServiceResponse<string>();
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
            response.Data = createToken(user);
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

        // Compare user Password with the one in database
        private bool comparePassword(string password, byte[] passwordHash, byte[] passwordSalt) {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        // Create token
        private string createToken(User user) {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var AppSetting = _configuration.GetSection("AppSetting:Token").Value;

            if(AppSetting is null) {
                throw new Exception("App Setting not found");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(AppSetting));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}