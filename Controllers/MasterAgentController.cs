using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MasterAgentController: ControllerBase
    {
        private readonly MasterAgentService _masterAgentService;
        public MasterAgentController(MasterAgentService masterAgentService)
        {
            _masterAgentService = masterAgentService;
            
        }

        [HttpPost]
        public async Task<ActionResult<GetMasterAgentDto>> createMasterAgent([FromBody] MasterAgentDto masterAgentDto) {
            if(!ModelState.IsValid) {
                return BadRequest(masterAgentDto);
            }

            return Ok(await _masterAgentService.CreateMasterAgent(masterAgentDto));
        }
        
        [AllowAnonymous]
        [HttpGet("GetListOfSuperAgentUnderMasterAgent")]
        public async Task<ActionResult<ServiceResponse<List<GetSuperAgent>>>> GetListOfSuperAgentUnderMasterAgent(int masterAgentId){
            return Ok(await _masterAgentService.GetListOfSuperAgentUnderMasterAgent(masterAgentId));
        }
    }
}