using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using SendEmail.Settings;
using System.IO;
using System.Threading.Tasks;

namespace SendEmail.Services
{
    public class MailServices : IMailServices
    {
        private readonly MailSettings _mailSettings;

        public MailServices(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task<string> SendEmail(string mailTo, string subject, string body, IList<IFormFile>? attachments = null)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_mailSettings.EMail),
                    Subject = subject,
                };

                email.To.Add(MailboxAddress.Parse(mailTo));
                email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.EMail));

                var builder = new BodyBuilder
                {
                    HtmlBody = body
                };

                if (attachments != null)
                {
                    foreach (var file in attachments)
                    {
                        if (file.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            await file.CopyToAsync(ms);
                            builder.Attachments.Add(file.FileName, ms.ToArray(), ContentType.Parse(file.ContentType));
                        }
                    }
                }

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.EMail, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return "The Message is sent";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
