using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptiLoan.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrganisationController: ControllerBase
    {
        private readonly OrganisationService _organisationService;
        public OrganisationController(OrganisationService organisationService)
        {
            _organisationService = organisationService;
            
        }

        [HttpPost]
        public async Task<ActionResult<GetOrganizationDto>> CreateOrganisation([FromBody] OrganizationDto organizationDto) {
            if(!ModelState.IsValid) {
                return BadRequest(organizationDto);
            }

            return Ok(await _organisationService.CreateOrganisation(organizationDto));
        }

    }
}