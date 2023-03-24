using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Services
{
    public interface OrganisationService
    {
        Task<ServiceResponse<GetOrganizationDto>> CreateOrganisation(OrganizationDto organizationDto);
        
    }
}