using Schedule.Core.Entities.Base;
using Schedule.Core.Enums;
using System.Collections.Generic;

namespace Schedule.Core.Entities.General
{
    public class Lesson : AuditEntity
    {
        public string Name { get; set; }
        public bool IsCompulsory { get; set; }
        public LessonType Type { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<TeacherLessons> Teachers { get; set; }
        public virtual ICollection<GroupLessons> Groups { get; set; }
    }
}
