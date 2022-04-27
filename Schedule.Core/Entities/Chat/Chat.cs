using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Chat
{
    public class Chat : AuditEntity
    {
        public string Name { get; set; }
        public Guid OrganizerId { get; set; }
        public virtual User Organizer { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserChats> Users { get; set; }
    }
}
