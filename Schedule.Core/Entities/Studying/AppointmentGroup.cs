using Schedule.Core.Entities.General;
using System;

namespace Schedule.Core.Entities.Studying
{
    public class AppointmentGroup
    {
        public Guid AppointmentId { get; set; }
        public Guid GroupId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Group Group { get; set; }
    }
}
