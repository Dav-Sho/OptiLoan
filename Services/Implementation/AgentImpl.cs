using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services.Implementation
{
    public class AgentImpl : AgentService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AgentImpl(DataContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
            
        }
        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetAgentDto>> CreateAgent(AgentDto agentDto)
        {
            var response = new ServiceResponse<GetAgentDto>();
            OrganizationClass userClass = new OrganizationClass();

            try{
                // find master agent
                var superAgent = await _context.SuperAgents.FirstOrDefaultAsync(s => s.Id == agentDto.SuperAgentId);

                // check if master agent exist
                if(superAgent is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Message = $"Super agent with the id{agentDto.SuperAgentId}";
                    return response;
                }

                // map super Agent dto to object
                var agent = _mapper.Map<Agent>(agentDto);

                agent.SuperAgent = superAgent;

                // gett current login user
                agent.user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                agent.UserClass = userClass.Agent;

                // add super agent tables to db
                _context.Agents.Add(agent);

                // Save db
                await _context.SaveChangesAsync();
                // response
                response.Data = _mapper.Map<GetAgentDto>(agent);
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Agent Created";
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