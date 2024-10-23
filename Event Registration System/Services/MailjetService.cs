using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace MVCAuth.Services
{
    public class MailjetService
    {
        private readonly IConfiguration _configuration;
        private readonly MailjetClient _client;

        public MailjetService(IConfiguration configuration, MailjetClient client)
        {
            _configuration = configuration;
            _client = new MailjetClient(_configuration["Mailjet:ApiKey"], _configuration["Mailjet:SecretKey"]);
        }

        public async Task<bool> SendEmail(string toEmail, string toName, string subject, string textPart, string htmlPart)
        {
            var request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "ibrahimnimer25@gmail.com")  // Corrected email
            .Property(Send.FromName, "Event App")
            .Property(Send.Subject, subject)
            .Property(Send.TextPart, textPart)
            .Property(Send.HtmlPart, htmlPart)  // Use htmlPart for the HTML version
            .Property(Send.Recipients, new JArray
            {
                new JObject
                {
                    {"Email", toEmail},
                    {"Name", toName }
                }
            });

            MailjetResponse response = await _client.PostAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
