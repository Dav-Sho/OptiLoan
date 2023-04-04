using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AgentController:ControllerBase
    {
        private readonly AgentService _agentService;
        public AgentController(AgentService agentService)
        {
            _agentService = agentService;
            
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetAgentDto>>> CreateAgent(AgentDto agentDto){
            return Ok(await _agentService.CreateAgent(agentDto));
        }
    }
}