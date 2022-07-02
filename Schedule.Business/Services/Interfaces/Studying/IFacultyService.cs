using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces.Studying
{
    public interface IFacultyService : IService, IDisposable
    {
        Task<ActionStatus> CreateAsync(Faculty faculty, CancellationToken cancellationToken = default);
        Task<FacultyDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(FacultyDto faculty, CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<FacultyDto>> GetOrganizatiosAsync(CancellationToken cancellationToken = default);
    }
}
