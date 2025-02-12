using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

using System.Globalization;


namespace Glitter.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        //private readonly IWebHostEnvironment webHost;

        public MailService(IOptions<MailSettings> mailSettingsOptions, IWebHostEnvironment webHost)
        {
            _mailSettings = mailSettingsOptions.Value;
            //this.webHost = webHost;
        }

        public async Task<bool> ReceiveEmailAsync(MailData mailData)
        {
            using var emailClient = new ImapClient();
            emailClient.Connect(_mailSettings.Host, _mailSettings.IMAPPort, _mailSettings.EnableSsl);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            emailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);

            using MimeMessage emailMessage = new();
            MailboxAddress emailTo = new(_mailSettings.Name, _mailSettings.Email);
            MailboxAddress emailFrom = new(mailData.ClientName, mailData.ClientId);

            BodyBuilder emailBodyBuilder = new()
            {
                TextBody = mailData.Body,
            };
            emailMessage.To.Add(emailTo);
            emailMessage.From.Add(emailFrom);
            emailMessage.Subject = mailData.Subject;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();
            try
            {
                await emailClient.Inbox.AppendAsync(emailMessage);
                emailClient.Disconnect(true);
                return true;
            }
            catch (Exception)
            {
                await emailClient.GetFolder("DRAFT").AppendAsync(emailMessage);
                emailClient.Disconnect(true);
                return false;
            }
        }
    }
}
