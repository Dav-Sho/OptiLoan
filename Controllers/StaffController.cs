using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StaffController: ControllerBase
    {
        private readonly StaffService _staffService;
        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
            
        }
        
        [HttpPost("CreateStaff")]
        public async Task<ActionResult<ServiceResponse<GetStaffDto>>> CreateStaff(StaffDto staffDto) {
            return Ok(await _staffService.CreateStaff(staffDto));
        }
    }
}