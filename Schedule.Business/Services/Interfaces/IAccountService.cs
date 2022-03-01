using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.Token;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<AuthResultDto> LoginAsync(AuthDto auth, CancellationToken cancellationToken = default);
        Task RegisterAsync(RegisterDto registerModel, CancellationToken cancellationToken = default);
        Task ConfirmRegistrationAsync(string registrationToken, CancellationToken cancellationToken = default);
        Task<AuthResultDto> UpdateRefreshTokenAsync(TokenUpdateDto tokenPair, CancellationToken cancellationToken = default);
    }
}
