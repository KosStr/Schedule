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
    public class FacultyController : ControllerBase
    {
        #region Properties

        private readonly IFacultyService _facultyService;

        #endregion

        #region Constructor

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Faculty faculty, CancellationToken cancellationToken = default)
        {
            return Ok(await _facultyService.CreateAsync(faculty, cancellationToken));
        }

        [HttpGet("faculty/{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _facultyService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FacultyDto faculty, CancellationToken cancellationToken = default)
        {
            return Ok(await _facultyService.UpdateAsync(faculty, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _facultyService.DeleteAsync(id, cancellationToken));
        }

        #endregion
    }
}
