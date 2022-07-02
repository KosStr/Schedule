using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces.Studying
{
    public interface INotificationService : IService, IDisposable
    {
        Task<ActionStatus> CreateAsync(NotificationDto notification, CancellationToken cancellationToken = default);
        Task<NotificationDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(NotificationDto notification, CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<NotificationDto>> GetByFacultyAsync(CancellationToken cancellationToken = default);
    }
}
