using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces
{
    public interface IUserService : IService, IDisposable
    {
        Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<UserDto>> GetGroupUsersAsync(CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(UserDto user, CancellationToken cancellationToken = default);
        Task<IEnumerable<NotificationDto>> GetNotificationsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<SubjectDto>> GetSubjectsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatDto>> GetChatsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}