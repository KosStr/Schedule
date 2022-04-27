using Schedule.Core.Entities.Base;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Subject : AuditEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TeacherSubjects> Teachers { get; set; }
    }
}
