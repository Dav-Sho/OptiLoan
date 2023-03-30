using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OptiLoan.Services
{
    public interface MasterAgentService
    {
        Task<ServiceResponse<GetMasterAgentDto>> CreateMasterAgent(MasterAgentDto masterAgentDto);
        Task<ServiceResponse<List<GetSuperAgent>>> GetListOfSuperAgentUnderMasterAgent(int masterAgentId);
    }
}