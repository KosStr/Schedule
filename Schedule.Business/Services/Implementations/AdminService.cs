using Schedule.Business.Services.Base;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.General;
using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.General;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations
{
    internal class AdminService : ServiceBase, IAdminService
    {
        #region Properties

        #endregion

        #region Constructor

        public AdminService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Interface Members

        public async Task AddGroup(GroupDto group)
        {
            if (group != null)
            {
                await UnitOfWork.Repository<Group>().CreateAsync(new Group
                {
                    Name = group.Name,
                    Grade = group.Grade,
                });

                await UnitOfWork.SaveChangesAsync();
            }
        }

        public Task<Group> AddGroup()
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> AddLesson()
        {
            throw new NotImplementedException();
        }

        public Task<Notification> AddNotification(NotificationDto notification)
        {
            //if (group != null)
            //{
            //    await UnitOfWork.Repository<Group>().CreateAsync(new Group
            //    {
            //        Name = group.Name,
            //        Grade = group.Grade,
            //    });

            //    await UnitOfWork.SaveChangesAsync();
            //}
            throw new NotImplementedException();
        }

        public Task<Notification> AddNotification()
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUser(UserDto user)
        {
            //if (group != null)
            //{
            //    await UnitOfWork.Repository<Group>().CreateAsync(new Group
            //    {
            //        Name = group.Name,
            //        Grade = group.Grade,
            //    });

            //    await UnitOfWork.SaveChangesAsync();
            //}
            throw new NotImplementedException();
        }

        public Task<User> AddUser()
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLesson(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> DeleteNotification()
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> UpdateGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> UpdateLesson(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> UpdateNotification()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
