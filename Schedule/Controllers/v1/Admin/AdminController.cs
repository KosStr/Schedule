using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Admin
{
    [RouteV1("[controller]"), Policy(Role.Admin)]
    public class UserController : ControllerBase
    {
        #region Properties

        private readonly IAdminService _adminService;

        #endregion

        #region Constructor

        public UserController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #endregion

        #region Actions

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _adminService.DeleteUserAsync(id, cancellationToken));
        }

        #endregion
    }
}
