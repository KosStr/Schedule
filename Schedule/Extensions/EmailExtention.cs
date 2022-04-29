using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using System;
using Schedule.Core.DTO.Email;

namespace Schedule.Extensions
{
    public static class EmailExtention
    {
        public static void AddEmail(this IServiceCollection services, IServiceProvider serviceProvider)
        {
            var emailSettings = serviceProvider.GetService<EmailSettings>();

            services.AddFluentEmail(emailSettings.From)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(emailSettings.SmtpSettings.Host, emailSettings.SmtpSettings.Port)
                {
                    Credentials = new NetworkCredential(emailSettings.SmtpSettings.SenderCredentials.SenderName, emailSettings.SmtpSettings.SenderCredentials.Password),
                    EnableSsl = true
                });
        }

    }
}
