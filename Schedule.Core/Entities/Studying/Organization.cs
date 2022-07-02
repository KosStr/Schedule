using Schedule.Core.Entities.Base;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Studying
{
    public class Organization: AuditEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
    }
}
