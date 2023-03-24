using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan
{
    public class AutoMApper: Profile
    {
        public AutoMApper()
        {
            CreateMap<MasterAgentDto, MasterAgent>();
            CreateMap<MasterAgent, GetMasterAgentDto>();
            CreateMap<OrganizationDto, Organization>();
            CreateMap<Organization, GetOrganizationDto>();
        }
    }
}