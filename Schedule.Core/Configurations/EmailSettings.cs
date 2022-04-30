using Schedule.Core.DTO.Email;

namespace Schedule.Core.Configurations
{
    public class EmailSettings
    {
        public string From { get; set; }
        public SmtpSettings SmtpSettings { get; set; }
    }
}
