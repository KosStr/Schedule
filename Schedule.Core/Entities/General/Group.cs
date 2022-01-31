using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Group : AuditEntity
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<GroupNotifications> Notifications { get; set; }
        public virtual ICollection<GroupLessons> Lessons { get; set; }
    }
}
