using System.Net.Mail;

namespace Glitter.Services
{
    public interface IMailService
    {
        //Task<bool> SendMailAsync(MailData mailData);
        Task<bool> ReceiveEmailAsync(MailData mailData);
    }
}
