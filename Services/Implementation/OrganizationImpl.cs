using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services.Implementation
{
    public class OrganizationImpl : OrganisationService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public OrganizationImpl(DataContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _context = context;
            
        }

        // Get login user id
        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public async Task<ServiceResponse<GetOrganizationDto>> CreateOrganisation(OrganizationDto organizationDto)
        {
            var response = new ServiceResponse<GetOrganizationDto>();

            try{
                var organization = _mapper.Map<Organization>(organizationDto);
                organization.user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                _context.Organizations.Add(organization);
                await _context.SaveChangesAsync();

                // response
                response.Data = _mapper.Map<GetOrganizationDto>(organization);
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Organization Created";
                return response;

            }catch(Exception ex){
                response.Success = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetMasterAgentDto>>> MasterAgentUnderOrganisation(int organisationId)
        {
            var response = new ServiceResponse<List<GetMasterAgentDto>>();

            try{
                  // find organisation
                var organization = await _context.Organizations.FirstOrDefaultAsync(o => o.Id == organisationId);

                // check if organisation is found
                if(organization is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Organisation not found";
                    return response;
                }

                // find the list of master under under the specific user
                var masterAgent = await _context.MasterAgents.Where(c => c.Organization == organization).ToListAsync();

                // check if there is no master agent under the organisation
                if(organization is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Organisation not found";
                    return response;
                }
                // return list of staff object & response
                response.Data = masterAgent.Select(m => _mapper.Map<GetMasterAgentDto>(m)).ToList();
                response.StatusCode = HttpStatusCode.OK;
                response.Message = $"List of MasterAgent under Organisation: {organization.Name}";
                return response;

            }catch(Exception ex){
                response.Success = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<List<GetStaffDto>>> StaffUnderOrganization(int organisationId)
        {
            var response = new ServiceResponse<List<GetStaffDto>>();

            try{
                // find organisation
                var organisation = await _context.Organizations.FirstOrDefaultAsync(o => o.Id == organisationId);

                // check if organisation is found
                if(organisation is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Organisation not found";
                    return response;
                }
                
                // find List of staff where organisation id is equal to staff.organisationId to list
                var staff = await _context.Staffs.Where(s => s.Organization == organisation).ToListAsync();

                // check if staff is null
                if(staff is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = $"Staff not found with Organisation id: {organisationId}";
                    return response;
                }

                // return list of staff object & response
                response.Data = staff.Select(s => _mapper.Map<GetStaffDto>(s)).ToList();
                response.StatusCode = HttpStatusCode.OK;
                response.Message = $"List of staff under Organisation: {organisation.Name}";
                return response;
            }catch(Exception ex) {
                response.Success = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}