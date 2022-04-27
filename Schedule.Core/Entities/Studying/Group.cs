using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.Studying;
using Schedule.Core.Enums;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Group : AuditEntity
    {
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<AppointmentGroups> Appointments { get; set; }
    }
}
