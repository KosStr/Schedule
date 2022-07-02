using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.General;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces.Studying
{
    public interface IGroupService : IService, IDisposable
    {
        Task<ActionStatus> CreateAsync(Group group, CancellationToken cancellationToken = default);
        Task<GroupDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(GroupDto group, CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<GroupDto>> GetByFacultyId(CancellationToken cancellationToken = default);
    }
}
