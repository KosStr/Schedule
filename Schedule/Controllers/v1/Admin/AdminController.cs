using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.Enums;

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

        #endregion
    }
}
