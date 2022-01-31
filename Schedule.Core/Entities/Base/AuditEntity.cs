using System;

namespace Schedule.Core.Entities.Base
{
    public abstract class AuditEntity : EntityBase
    {
        public DateTime? CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
