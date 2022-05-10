using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Account
{
    [RouteV1("[controller]"), Policy(Role.Student, Role.Teacher)]
    public class UserController : ControllerBase
    {
        #region Properties

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Actions

        [HttpGet("group")]
        public async Task<IActionResult> GetGroupUsersAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetGroupUsersAsync(cancellationToken));
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAppointmentsAsync(CancellationToken cancellationToken)
        {
            return Ok( await _userService.GetAppointmentsAsync(cancellationToken));
        }

        [HttpGet("chats")]
        public async Task<IActionResult> GetChatsAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetChatsAsync(cancellationToken));
        }

        [HttpGet("grades")]
        public async Task<IActionResult> GetGradesAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetGradesAsync(cancellationToken));
        }

        [HttpGet("grades/{subjectId}")]
        public async Task<IActionResult> GetGradesAsync(Guid subjectId, CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetSubjectGradesAsync(subjectId, cancellationToken));
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjectsAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetSubjectsAsync(cancellationToken));
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotificationsAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetNotificationsAsync(cancellationToken));
        }

        #endregion
    }
}
