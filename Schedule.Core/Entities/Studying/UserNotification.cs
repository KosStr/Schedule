using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.General
{
    public class UserNotification: ISqlEntity
    {
        public Guid NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}