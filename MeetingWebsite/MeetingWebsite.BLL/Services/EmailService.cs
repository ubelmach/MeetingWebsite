using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MeetingWebsite.BLL.Builders;
using Microsoft.AspNetCore.Hosting;
using MimeKit;

namespace MeetingWebsite.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IHostingEnvironment _appEnvironment;

        public EmailService(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new EmailBuilder().From().To(email).Subject(subject).Body(message).Build();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(Constants.Smtp_Host, int.Parse(Constants.Smtp_Port), false);
                await client.AuthenticateAsync(Constants.Smtp_UserName, Constants.Smtp_Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}