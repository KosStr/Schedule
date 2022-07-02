using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.Studying;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Group : AuditEntity
    {
        public string Name { get; set; }
        public Guid FacultyId {get;set;}
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();    
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<AppointmentGroup> AppointmentGroups { get; set; } = new List<AppointmentGroup>();
    }
}
