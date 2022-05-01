using Schedule.Core.Entities.Base;
using Schedule.Core.Entities.Communication;
using Schedule.Core.Entities.General;
using Schedule.Core.Entities.Studying;
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
        public DateTime ActivatedDate { get; set; }
        public string EmailToken { get; set; }
        public DateTime EmailTokenLifetime { get; set; }
        public Guid? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual RefreshToken Token { get; set; }

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public virtual ICollection<UserNotification> UserNotifications { get; set; } = new List<UserNotification>();
        public virtual ICollection<Chat> OrganizedChats { get; set; } = new List<Chat>();
        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public virtual ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();
        public virtual ICollection<Appointment> TeacherAppointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Assignment> TeacherAssignments { get; set; } = new List<Assignment>();
        public virtual ICollection<Attachment> StudentAttachments { get; set; } = new List<Attachment>();
        public virtual ICollection<File> UploadedFiles { get; set; } = new List<File>();
        public virtual ICollection<Message> SentMessages { get; set; } = new List<Message>();

        public void SetEmailToken(string emailToken, int hoursLifetime)
        {
            EmailToken = emailToken;
            EmailTokenLifetime = DateTime.Now.AddHours(hoursLifetime);
        }
    }
}
