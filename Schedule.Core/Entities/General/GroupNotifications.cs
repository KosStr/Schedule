using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Core.Entities.General
{
    public class GroupNotifications
    {
        public Guid NotificationId { get; set; }
        public Guid GroupId { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual Group Group { get; set; }
    }
}
