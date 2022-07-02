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
    [RouteV1("[controller]")]
    public class NotificationController : ControllerBase
    {
        #region Properties

        private readonly INotificationService _notificationService;

        #endregion

        #region Constructor

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NotificationDto notification, CancellationToken cancellationToken = default)
        {
            return Ok(await _notificationService.CreateAsync(notification, cancellationToken));
        }

        [HttpGet("notification/{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _notificationService.GetAsync(id, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] NotificationDto notification, CancellationToken cancellationToken = default)
        {
            return Ok(await _notificationService.UpdateAsync(notification, cancellationToken));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _notificationService.DeleteAsync(id, cancellationToken));
        }

        [HttpGet("faculty")]
        public async Task<IActionResult> GetByFacultyAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _notificationService.GetByFacultyAsync(cancellationToken));
        }

        #endregion
    }
}
