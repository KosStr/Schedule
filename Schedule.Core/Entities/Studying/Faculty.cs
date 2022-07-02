using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Studying
{
    public class Faculty : AuditEntity
    {
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}