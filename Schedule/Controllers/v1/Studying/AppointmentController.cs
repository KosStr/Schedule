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
    [RouteV1("[controller]"), Policy(Role.Teacher)]
    public class AppointmentController : ControllerBase
    {
        #region Properties

        private readonly IAppointmentService _appointmentService;

        #endregion

        #region Constructor

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Appointment appointment, CancellationToken cancellationToken = default)
        {
            return Ok(await _appointmentService.CreateAsync(appointment, cancellationToken));
        }

        [HttpGet("appointment/{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _appointmentService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] AppointmentDto appointment, CancellationToken cancellationToken = default)
        {
            return Ok(await _appointmentService.UpdateAsync(appointment, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _appointmentService.DeleteAsync(id, cancellationToken));
        }

        #endregion
    }
}
