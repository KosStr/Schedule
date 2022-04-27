using Schedule.Core.Entities.Account;
using System;

namespace Schedule.Core.Entities.General
{
    public class UserNotifications
    {
        public Guid NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
        public Guid UsertId { get; set; }
        public virtual User User { get; set; }
    }
}
