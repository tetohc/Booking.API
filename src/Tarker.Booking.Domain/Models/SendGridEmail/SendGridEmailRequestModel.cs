namespace Tarker.Booking.Domain.Models.SendGridEmail
{
    /// <summary>
    /// SendGrid Email Request Model
    /// </summary>
    public class SendGridEmailRequestModel
    {
        public ContentEmail From { get; set; }
        public List<Personalization> Personalizations { get; set; }
        public List<ContentBody> Content { get; set; }
    }

    /// <summary>
    /// Email Address
    /// </summary>
    public class ContentEmail
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Email Content
    /// </summary>
    public class ContentBody
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// Personalization if needed to send email to multiple recipients
    /// </summary>
    public class Personalization
    {
        public string Subject { get; set; }
        public List<ContentEmail> To { get; set; }
    }
}