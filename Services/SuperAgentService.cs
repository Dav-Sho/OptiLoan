using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services
{
    public interface SuperAgentService
    {
        Task<ServiceResponse<GetSuperAgent>> CreateSuperagent(SuperAgentDto superAgentDto);
    }
}