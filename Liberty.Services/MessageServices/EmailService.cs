using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SendGrid;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Liberty.Services.MessageServices
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await SendEmailAsync(message);
        }

        private async Task SendEmailAsync(IdentityMessage message)
        {
            var email = new SendGridMessage
            {
                From = new MailAddress("yourmailaddress@mail.com", "Your Fullname"),
                Subject = message.Subject,
                Text = message.Body,
                Html = message.Body
            };

            email.AddTo(message.Destination);

            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailALibertyount"], ConfigurationManager.AppSettings["MailPassword"]);

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            await transportWeb.DeliverAsync(email);
        }
    }
}
