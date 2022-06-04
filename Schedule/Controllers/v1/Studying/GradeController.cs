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
    public class GradeController : ControllerBase
    {
        #region Properties

        private readonly IGradeService _gradeService;

        #endregion

        #region Constructor

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Grade grade, CancellationToken cancellationToken = default)
        {
            return Ok(await _gradeService.CreateAsync(grade, cancellationToken));
        }

        [HttpGet("grade/{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _gradeService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] GradeDto grade, CancellationToken cancellationToken = default)
        {
            return Ok(await _gradeService.UpdateAsync(grade, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _gradeService.DeleteAsync(id, cancellationToken));
        }

        [HttpGet("grades")]
        public async Task<IActionResult> GetGradesAsync(CancellationToken cancellationToken)
        {
            return Ok(await _gradeService.GetGradesAsync(cancellationToken));
        }

        [HttpGet("grades/{subjectId}")]
        public async Task<IActionResult> GetGradesAsync(Guid subjectId, CancellationToken cancellationToken)
        {
            return Ok(await _gradeService.GetSubjectGradesAsync(subjectId, cancellationToken));
        }

        #endregion
    }
}
