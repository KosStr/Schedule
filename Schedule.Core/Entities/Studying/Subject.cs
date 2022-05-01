using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.Studying;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Subject : AuditEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public virtual ICollection<User> Teachers { get; set; } = new List<User>();
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}
