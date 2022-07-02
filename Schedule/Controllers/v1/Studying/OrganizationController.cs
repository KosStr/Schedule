using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Studying
{
    [RouteV1("[controller]")]
    public class OrganizationController : ControllerBase
    {
        #region Properties

        private readonly IOrganizationService _organizationService;

        #endregion

        #region Constructor

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Organization organization, CancellationToken cancellationToken = default)
        {
            return Ok(await _organizationService.CreateAsync(organization, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _organizationService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] OrganizationDto organization, CancellationToken cancellationToken = default)
        {
            return Ok(await _organizationService.UpdateAsync(organization, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _organizationService.DeleteAsync(id, cancellationToken));
        }

        #endregion
    }
}
