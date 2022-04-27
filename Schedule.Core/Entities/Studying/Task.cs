using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.Studying
{
    public class Task : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
