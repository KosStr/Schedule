using Autofac;
using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Controllers.Base;
using Schedule.Core.DTO.Account;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Account
{
    [RouteV1("[controller]")]
    public class AccountController : BaseController
    {
        #region Constructor

        public AccountController(ILifetimeScope scope) : base(scope)
        {
        }

        #endregion

        #region Actions

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthDto authDto)
        {
            await Service<IAccountService>().LoginAsync(authDto);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            return Ok();
        }

        #endregion
    }
}
