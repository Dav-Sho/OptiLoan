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
    }
}