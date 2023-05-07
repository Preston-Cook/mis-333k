using Candid.Models;

namespace Candid.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}