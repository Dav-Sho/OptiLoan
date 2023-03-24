using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services.Implementation
{
    public class MasterAgentImpl : MasterAgentService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public MasterAgentImpl(DataContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _context = context;
            
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);            
        public async Task<ServiceResponse<GetMasterAgentDto>> CreateMasterAgent(MasterAgentDto masterAgentDto)
        {
            var response = new ServiceResponse<GetMasterAgentDto>();

            try{
                // Mapping MasterAgentDto to Master Agent Class
                var masterAgent = _mapper.Map<MasterAgent>(masterAgentDto);

                // Putting user value to the masterAgent class
                masterAgent.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

                // Adding to master agent table
                _context.MasterAgents.Add(masterAgent);

                // Saving master agent table to data base
                await _context.SaveChangesAsync();

                // response
                response.Data = _mapper.Map<GetMasterAgentDto>(masterAgent);
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Master Agent created";
                return response;
            }catch(Exception ex) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        


       
    }
}