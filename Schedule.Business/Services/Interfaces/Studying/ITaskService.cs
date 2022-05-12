using Schedule.Core.DTO.Studying;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using StudyngTask = Schedule.Core.Entities.Studying.Task;

namespace Schedule.Business.Services.Interfaces.Studying
{
    public interface ITaskService : IService, IDisposable
    {
        Task<ActionStatus> CreateAsync(StudyngTask task, CancellationToken cancellationToken = default);
        Task<TaskDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(TaskDto task, CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
