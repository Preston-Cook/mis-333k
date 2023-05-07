using Candid.Models;
using MimeKit;

namespace Candid.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailDTO request)
        {
            // Retrieve email creds from environment
            var CandidEmail = "";
            var CandidPassword = "";
            
            // Create email message and set necessary properties
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(CandidEmail));
            email.To.Add(MailboxAddress.Parse(CandidEmail)); // Send email to candid email for now
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body.Replace(@"\n", "<br/>").Replace(@"\r", "").Replace(@"\'", "'") };

            // Context manager for smtp connection
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            // Authenticate Candid email creds, send email, and disconnect
            smtp.Authenticate(CandidEmail, CandidPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}