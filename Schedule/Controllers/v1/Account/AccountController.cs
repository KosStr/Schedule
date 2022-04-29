using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.DTO.Account;
using Schedule.Core.Helpers;
using System.Threading.Tasks;

namespace Schedule.Controllers.v1.Account
{
    [RouteV1("[controller]")]
    public class AccountController : ControllerBase
    {
        #region Properties

        private readonly IAccountService _accountService;

        #endregion

        #region Constructor

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion

        #region Actions
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="authDto"></param>
        /// <returns>Access token and logged in user</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthDto authDto)
        {
            var authResult = await _accountService.LoginAsync(authDto);
            HttpContext.Response.Cookies.Append(
              Constants.Cookies.RefreshTokenKey,
              authResult.RefreshToken,
               new CookieOptions
               {
                   HttpOnly = true,
                   Secure = true,
                   SameSite = SameSiteMode.Strict,
                   Expires = authResult.RefreshExpiry
               });
            //add Dto;
            return Ok(new { AccessToken = authResult.JwtToken, User = authResult.User });
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns>Ok</returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            await _accountService.RegisterAsync(registerDto);
            return Ok();
        }

        /// <summary>
        /// Register confirmation process
        /// </summary>
        /// <param name="registerToken"></param>
        /// <returns>Ok</returns>
        [HttpPost("confirm/{registerToken}")]
        public async Task<IActionResult> ConfirmRegistrationAsync(string registerToken)
        {
            await _accountService.ConfirmRegistrationAsync(registerToken);
            return Ok();
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>Ok</returns>
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (HttpContext.Request.Cookies.ContainsKey(Constants.Cookies.RefreshTokenKey))
            {
                HttpContext.Response.Cookies.Delete(Constants.Cookies.RefreshTokenKey);
            }
            return Ok();
        }

        #endregion
    }
}
