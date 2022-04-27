using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Studying
{
    public class Appointment : AuditEntity
    {
        public DateTime FromDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsOnline { get; set; }
        public string Link { get; set; }
        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid TeacherId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual ICollection<AppointmentGroups> Groups { get; set; }

    }
}
