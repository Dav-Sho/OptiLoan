using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SuperAgentController: ControllerBase
    {
        public SuperAgentService _SuperAgentService { get; }
        public SuperAgentController(SuperAgentService superAgentService)
        {
            _SuperAgentService = superAgentService;
            
        }

        [HttpPost("Create SuperAgent")]
        public async Task<ActionResult<ServiceResponse<GetSuperAgent>>> CreateSuperagent(SuperAgentDto superAgentDto) {
            return Ok(await _SuperAgentService.CreateSuperagent(superAgentDto));
        }
    }
}