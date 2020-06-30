using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Threading.Tasks;

namespace Liberty.Services.MessageServices
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //var Twilio = new TwilioRestClient(ConfigurationManager.AppSettings["TwilioSid"], ConfigurationManager.AppSettings["TwilioToken"]);

            //var result = Twilio.SendMessage(ConfigurationManager.AppSettings["TwilioFromPhone"], message.Destination, message.Body);

            // Status is one of Queued, Sending, Sent, Failed or null if the number is not valid
            //Trace.TraceInformation(result.Status);

            // Twilio doesn't currently have an async API, so return suLibertyess.
            return Task.FromResult(0);
        }
    }
}
