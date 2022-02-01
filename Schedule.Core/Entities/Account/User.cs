using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Token;
using Schedule.Core.Enums;
using System;
using System.Collections.Generic;

namespace Schedule.Core.Entities.Account
{
    public class User : AuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public string PasswordHash { get; set; }
        public Guid GroupId { get; set; }
        public Guid TokenId { get; set; }
        public virtual Group Group { get; set; }
        public virtual RefreshToken Token { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<TeacherLessons> Lessons { get; set; }

    }
}
