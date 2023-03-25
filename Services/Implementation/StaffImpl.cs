using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services.Implementation
{
    public class StaffImpl : StaffService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public StaffImpl(DataContext context, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _context = context;
            
        }

        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);            
        public async Task<ServiceResponse<GetStaffDto>> CreateStaff(StaffDto staffDto)
        {
            var response = new ServiceResponse<GetStaffDto>();

            try{
                // Initializing Organisation class;
                OrganizationClass userClass = new OrganizationClass();

                // find the organisation;
                var organization = await _context.Organizations.FirstOrDefaultAsync(o => o.Id == staffDto.OrganizationId);

                if(organization is null) {
                    response.Success = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Message = "Organisation not found";
                    return response;
                }

                // Mapping staffDto to staffs Class
                var staff = _mapper.Map<Staff>(staffDto);

                // Implementing UserType(example: Master Agent)
                staff.UserClass = userClass.Staff;

                // Implement the organization
                staff.Organization = organization;

                // Putting user value to the masterAgent class
                staff.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                Console.WriteLine("User", staff.User);

                // Adding to Staffs table
                _context.Staffs.Add(staff);

                // Saving staff table to data base
                await _context.SaveChangesAsync();

                // response
                response.Data = _mapper.Map<GetStaffDto>(staff);
                response.StatusCode = HttpStatusCode.Created;
                response.Message = "Staff created";
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