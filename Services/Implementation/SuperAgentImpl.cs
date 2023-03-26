using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services.Implementation
{
    public class SuperAgentImpl : SuperAgentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public SuperAgentImpl(IMapper mapper, DataContext context, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _mapper = mapper;
            
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetSuperAgent>> CreateSuperagent(SuperAgentDto superAgentDto)
        {
            var response = new ServiceResponse<GetSuperAgent>();
            OrganizationClass userClass = new OrganizationClass();

            try{
                // find master agent
                var masterAgent = await _context.MasterAgents.FirstOrDefaultAsync(m => m.Id == superAgentDto.MasterAgentId);

                // check if master agent exist
                if(masterAgent is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Message = $"Master agent with the id{superAgentDto.MasterAgentId}";
                    return response;
                }

                // map super Agent dto to object
                var superAgent = _mapper.Map<SuperAgent>(superAgentDto);

                superAgent.MasterAgent = masterAgent;

                // gett current login user
                superAgent.user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                superAgent.UserClass = userClass.SuperAgent;

                // add super agent tables to db
                _context.SuperAgents.Add(superAgent);

                // Save db
                await _context.SaveChangesAsync();
                // response
                response.Data = _mapper.Map<GetSuperAgent>(superAgent);
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Super Agent Created";
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