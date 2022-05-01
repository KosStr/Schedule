using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Notification : AuditEntity
    {
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Message { get; set; }
        public NotificationPriority Priority { get; set; }
        public NotificationType Type { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
    }
}
