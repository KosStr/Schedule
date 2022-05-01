using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;

namespace Schedule.Core.Entities.Communication
{
    public class Message : AuditEntity
    {
        public string Text { get; set; }
        public Guid SenderId { get; set; }
        public virtual User Sender { get; set; }
        public Guid ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public bool IsRead { get; set; }
    }
}
