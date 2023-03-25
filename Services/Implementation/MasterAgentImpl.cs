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
                // Initializing Organisation class;
                OrganizationClass userClass = new OrganizationClass();

                // find the organisation;
                var organization = await _context.Organizations.FirstOrDefaultAsync(o => o.Id == masterAgentDto.OrganizationId);

                if(organization is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Organisation not found";
                    return response;
                }

                // Mapping MasterAgentDto to Master Agent Class
                var masterAgent = _mapper.Map<MasterAgent>(masterAgentDto);

                // Implementing UserType(example: Master Agent)
                masterAgent.UserClass = userClass.MasterAgent;
                // Implement the organization
                masterAgent.Organization = organization;

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