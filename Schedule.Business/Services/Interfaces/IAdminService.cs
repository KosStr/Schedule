using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.General;
using System;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Group> AddGroup();
        Task<Group> UpdateGroup(Group group);
        Task DeleteGroup(Guid id);
        Task<Lesson> AddLesson();
        Task<Lesson> UpdateLesson(Lesson lesson);
        Task DeleteLesson(Guid id);
        Task<Notification> AddNotification();
        Task<Notification> UpdateNotification();
        Task<Notification> DeleteNotification();
        Task<User> AddUser();
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(Guid id);
    }
}
