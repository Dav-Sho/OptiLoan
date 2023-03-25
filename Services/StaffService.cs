using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services
{
    public interface StaffService
    {
        Task<ServiceResponse<GetStaffDto>> CreateStaff(StaffDto staffDto);
    }
}