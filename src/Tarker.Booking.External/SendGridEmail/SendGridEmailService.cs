using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Tarker.Booking.Application.External.SendGridEmail;
using Tarker.Booking.Domain.Models.SendGridEmail;

namespace Tarker.Booking.External.SendGridEmail
{
    public class SendGridEmailService : ISendGridEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Send email using SendGrid API.
        /// </summary>
        /// <param name="model">SendGrid Email Request Model.</param>
        /// <returns></returns>
        public async Task<bool> Execute(SendGridEmailRequestModel model)
        {
            bool result = false;
            string apiKey = _configuration["SendGridEmailKey"];
            string apiUrl = "https://api.sendgrid.com/v3/mail/send";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string emailContent = JsonConvert.SerializeObject(model);
                var response = await client.PostAsync(apiUrl, new StringContent(emailContent, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    result = true;
            }
            return result;
        }
    }
}