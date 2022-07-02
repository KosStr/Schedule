using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Studying
{
    [RouteV1("[controller]"), Policy(Role.Student, Role.Admin)]
    public class GroupController : ControllerBase
    {
        #region Properties

        private readonly IGroupService _groupService;

        #endregion

        #region Constructor

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Group group, CancellationToken cancellationToken = default)
        {
            return Ok(await _groupService.CreateAsync(group, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _groupService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] GroupDto group, CancellationToken cancellationToken = default)
        {
            return Ok(await _groupService.UpdateAsync(group, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _groupService.DeleteAsync(id, cancellationToken));
        }

        [HttpGet("faculty")]
        public async Task<IActionResult> GetByFacultyAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _groupService.GetByFacultyId(cancellationToken));
        }

        #endregion
    }
}
