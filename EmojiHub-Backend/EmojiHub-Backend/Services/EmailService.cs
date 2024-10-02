using EmojiHub_Backend.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Diagnostics;
namespace EmojiHub_Backend.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _configuration; 
        public EmailService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }


        public async Task<ServiceResponse<bool>> SendEmail(Email email)
        {

            string logoUrl = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Assets", "myLogo.png");

            var confirmationMessage = new MimeMessage();
            confirmationMessage.From.Add(new MailboxAddress("From:", _configuration["EmailSettings:Email"]));
            confirmationMessage.To.Add(new MailboxAddress("", email.EmailFrom));

            var confMessageHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Emails", "confirmation_email_htmlpage.html");

            var confMessageHtml = await File.ReadAllTextAsync(confMessageHtmlPath);

            string confMessageHtmlReplaced = confMessageHtml.Replace("{{logoUrl}}", logoUrl);

            var confMessageBuilder = new BodyBuilder
            {
                HtmlBody= confMessageHtml,
            };

            confirmationMessage.Body = confMessageBuilder.ToMessageBody();
            


            var response = new ServiceResponse<bool>();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mail from:", email.EmailFrom));
            message.To.Add(new MailboxAddress("", "hamzagorcevic100@gmail.com"));
            message.ReplyTo.Add(new MailboxAddress(email.Name ?? "User", email.EmailFrom));
            message.Subject = "Emoji Hub";

            message.Body = new TextPart("plain") { Text = email.EmailBody };


            var emailTemplate = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Emails", "email_htmlpage.html");

            string htmlTemplate = await File.ReadAllTextAsync(emailTemplate);

            string htmlBody = htmlTemplate.Replace("{{name}}", email.Name).Replace("{{body}}", email.EmailBody).Replace("{{logoUrl}}", logoUrl);

            var bodydBuilder = new BodyBuilder
            {
                HtmlBody = htmlBody
            };

            message.Body = bodydBuilder.ToMessageBody();


            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(_configuration["EmailSettings:ServerService"], _configuration.GetValue<int>("EmailSettings:Port"), SecureSocketOptions.StartTls);
                    client.Authenticate(_configuration["EmailSettings:Email"], _configuration["EmailSettings:Password"]);

                    client.Send(message);
                    client.Send(confirmationMessage);
                    client.Disconnect(true);
                }
                response.Success = true;
                response.Value = true;
                response.Message = "Successfuly sent";
                return response;
            }
            catch (Exception ex)
            {
                response.Value = false;
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }
    }
}
