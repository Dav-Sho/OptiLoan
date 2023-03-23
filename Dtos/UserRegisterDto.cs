using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Please use a valid email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password can not be less than 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        
        
        
        
        
        
        
        
    }
}