using Schedule.Core.Entities.Account;
using Schedule.Core.Entities.Communication;
using System;
using System.Collections.Generic;

namespace Schedule.Core.DTO.Studying
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? OrganizerId { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<User> Participants { get; set; }
    }
}
