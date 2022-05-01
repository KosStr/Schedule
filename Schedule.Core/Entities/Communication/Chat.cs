using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Communication
{
    public class Chat : AuditEntity
    {
        public string Name { get; set; }
        public Guid? OrganizerId { get; set; }
        public virtual User Organizer { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<User> Participants { get; set; } = new List<User>();
        public virtual ICollection<UserChat> ParticipantChats { get; set; } = new List<UserChat>();
    }
}
