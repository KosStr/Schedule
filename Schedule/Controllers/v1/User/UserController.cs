﻿using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Account
{
    [RouteV1("[controller]"), Policy(Role.Student, Role.Teacher, Role.Admin)]
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

        [HttpGet("members")]
        public async Task<IActionResult> GetGroupUsersAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetGroupUsersAsync(cancellationToken));
        }

        [HttpGet("facultyMembers")]
        public async Task<IActionResult> GetFacultyUsersAsync(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetFacultyUsersAsync(cancellationToken));
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _userService.DeleteAsync(id, cancellationToken));
        }

        #endregion
    }
}
