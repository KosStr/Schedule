using Schedule.Core.DTO.Account;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<AuthResult> LoginAsync(AuthDto auth, CancellationToken cancellationToken = default);
        Task<AuthResult> UpdateRefreshTokenAsync(AuthResult tokenPair, CancellationToken cancellationToken = default);
    }
}
