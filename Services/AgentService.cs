using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services
{
    public interface AgentService
    {
        Task<ServiceResponse<GetAgentDto>> CreateAgent(AgentDto agentDto);
    }
}