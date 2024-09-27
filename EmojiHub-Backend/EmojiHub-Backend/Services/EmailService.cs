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
            var response = new ServiceResponse<bool>(); 
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mail from:", email.EmailFrom));
            message.To.Add(new MailboxAddress("", "hamzagorcevic100@gmail.com"));
            message.ReplyTo.Add(new MailboxAddress(email.Name ?? "User", email.EmailFrom));
            message.Subject = "Emoji Hub";
            message.Body = new TextPart("plain") { Text = email.EmailBody };
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(_configuration["EmailSettings:ServerService"], _configuration.GetValue<int>("EmailSettings:Port"), SecureSocketOptions.StartTls);
                    client.Authenticate(_configuration["EmailSettings:Email"], _configuration["EmailSettings:Password"]);

                    client.Send(message);
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
