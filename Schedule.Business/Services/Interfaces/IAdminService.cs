using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces
{
    public interface IAdminService : IService, IDisposable
    {
        Task<ActionStatus> DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
