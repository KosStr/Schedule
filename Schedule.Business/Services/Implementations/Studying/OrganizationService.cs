using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces.Studying;
using Schedule.Core.DTO.Studying;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations.Studying
{
    internal class OrganizationService : ServiceBase, IOrganizationService
    {
        #region Properties

        private readonly Lazy<ICurrentUser> currentUser;

        #endregion

        #region Constructor

        public OrganizationService(IUnitOfWork unitOfWork,
             Lazy<ICurrentUser> currentUser)
            : base(unitOfWork)
        {
            this.currentUser = currentUser;
        }

        #endregion

        #region Interface Members

        public Task<ActionStatus> CreateAsync(Organization organization, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ActionStatus> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<OrganizationDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.Repository<Organization>().GetFirstAsync(i => i.Id == id, i => new OrganizationDto
            {
                Id = i.Id,
                Name = i.Name,
                Faculties = i.Faculties.Select(f => new FacultyDto
                {
                    Id = f.Id,
                    Name = f.Name   
                })
            }, cancellationToken);
        }

        public Task<IEnumerable<OrganizationDto>> GetOrganizatiosAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ActionStatus> UpdateAsync(OrganizationDto organization, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
