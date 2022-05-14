using Microsoft.Extensions.DependencyInjection;
using Schedule.Core.Configurations;
using System.Net;
using System.Net.Mail;

namespace Schedule.Extensions
{
    public static class EmailExtention
    {
        public static void AddEmail(this IServiceCollection services)
        {
            var emailSettings = services.BuildServiceProvider()
                .GetRequiredService<EmailSettings>();

            services.AddFluentEmail(emailSettings.From)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(emailSettings.SmtpSettings.Host, emailSettings.SmtpSettings.Port)
                {
                    Credentials = new NetworkCredential(emailSettings.SmtpSettings.SenderCredentials.SenderName, emailSettings.SmtpSettings.SenderCredentials.Password),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                });
        }

    }
}
