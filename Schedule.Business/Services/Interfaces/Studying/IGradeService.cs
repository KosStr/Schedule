using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces.Studying
{
    public interface IGradeService : IService, IDisposable
    {
        Task<ActionStatus> CreateAsync(Grade grade, CancellationToken cancellationToken = default);
        Task<GradeDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(GradeDto grade, CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
