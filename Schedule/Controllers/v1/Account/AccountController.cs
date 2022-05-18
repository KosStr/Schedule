using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Attributes;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.Token;
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

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] AuthDto authDto)
        {
            var authResult = await _accountService.LoginAsync(authDto);
            HttpContext.Response.Cookies.Append(
              Constants.Cookies.RefreshTokenKey,
              authResult.RefreshToken,
               new CookieOptions
               {
                   HttpOnly = false,
                   Secure = false,
                   SameSite = SameSiteMode.Strict,
                   Expires = authResult.RefreshExpiry
               });

            //add Dto;
            return Ok(new { AccessToken = authResult.JwtToken, User = authResult.User, Status = authResult.Status });
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            await _accountService.RegisterAsync(registerDto);
            return Ok();
        }

        [HttpPost("confirm/{registerToken}"), AllowAnonymous]
        public async Task<IActionResult> ConfirmRegistrationAsync(string registerToken)
        {
            await _accountService.ConfirmRegistrationAsync(registerToken);
            return Ok();
        }

        [HttpPost("resfresh")]
        public async Task<IActionResult> UpdateRefreshAsync([FromBody] TokenUpdateDto tokens)
        {
            return Ok(await _accountService.UpdateRefreshTokenAsync(tokens));
        }

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
