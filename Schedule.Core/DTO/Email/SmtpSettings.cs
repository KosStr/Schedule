namespace Schedule.Core.DTO.Email
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public SenderCredentials SenderCredentials { get; set; }
    }
}
