using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptiLoan.Dtos;

namespace OptiLoan.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
            
        }

//       routes
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register([FromBody]UserRegisterDto userDto){
            if(!ModelState.IsValid) {
                return BadRequest(userDto);
            }

            return Ok(await _authService.Resgister(
                new User{Username = userDto.Username, Email = userDto.Email}, userDto.Password
            ));
        }


//      Login Routes
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login([FromBody]UserLoginDto userDto){
            if(!ModelState.IsValid) {
                return BadRequest(userDto);
            }

            return Ok(await _authService.Login(userDto.Email, userDto.Password));
        }
    }
}