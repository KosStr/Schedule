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
    [RouteV1("[controller]"), Policy(Role.Teacher)]
    public class SubjectController : ControllerBase
    {
        #region Properties

        private readonly ISubjectService _subjectService;

        #endregion

        #region Constructor

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Subject subject, CancellationToken cancellationToken = default)
        {
            return Ok(await _subjectService.CreateAsync(subject, cancellationToken));
        }

        [HttpGet("subject/{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _subjectService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] SubjectDto subject, CancellationToken cancellationToken = default)
        {
            return Ok(await _subjectService.UpdateAsync(subject, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _subjectService.DeleteAsync(id, cancellationToken));
        }

        #endregion
    }
}
