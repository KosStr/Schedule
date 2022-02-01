using Schedule.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Schedule.Business.Services.Interfaces
{
    public interface IAccountService : IDisposable
    {
        JwtSecurityToken CreateToken(IEnumerable<Claim> claims, int activeTime = Constants.Jwt.Lifetime);
    }
}
