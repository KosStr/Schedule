using Microsoft.IdentityModel.Tokens;
using Schedule.Business.Managers.Base;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.DTO.Account;
using Schedule.Core.Entities.Account;
using Schedule.Core.Helpers;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations
{
    internal class AccountService : ServiceBase, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public JwtSecurityToken CreateToken(IEnumerable<Claim> claims, int activeTime = 6)
        {
            return new JwtSecurityToken(
                issuer: Constants.Jwt.Issuer,
                audience: Constants.Jwt.Audience,
                notBefore: DateTime.UtcNow,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(activeTime)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.Jwt.Key)), SecurityAlgorithms.HmacSha512));
        }

        //public async Task<AuthResult> LoginAsync(AuthDto auth, CancellationToken cancellationToken = default)
        //{
        //    var user = await UnitOfWork.Repository<User>().GetFirstAsync(u => u.Email == auth.Email,
        //        u => new UserDto
        //        {
        //            Id = u.Id,
        //            Email = u.Email,
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //            Role = u.Role
        //        }, cancellationToken);

        //    if (user == null) 
        //    {

        //    }
        //}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
