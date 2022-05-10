using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using System;

namespace Schedule.Core.Entities.Studying
{
    public class AppointmentGroup: ISqlEntity
    {
        public Guid AppointmentId { get; set; }
        public Guid GroupId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Group Group { get; set; }
    }
}
