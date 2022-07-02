using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces.Studying
{
    public interface IOrganizationService : IService, IDisposable
    {
        Task<ActionStatus> CreateAsync(Organization organization, CancellationToken cancellationToken = default);
        Task<OrganizationDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ActionStatus> UpdateAsync(OrganizationDto organization, CancellationToken cancellationToken = default);
        Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<OrganizationDto>> GetOrganizatiosAsync(CancellationToken cancellationToken = default);
    }
}
