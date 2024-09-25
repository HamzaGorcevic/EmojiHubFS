using EmojiHub_Backend.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
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
            message.From.Add(new MailboxAddress("FromName", "hamzagorcevic100@gmail.com"));
            message.To.Add(new MailboxAddress("", email.EmailFrom));
            message.Subject = "Emoji Hub";
            message.Body = new TextPart("plain") { Text = email.EmailBody };
            Console.WriteLine($"Server: {_configuration["EmailSettings:ServerService"]}");

            try
            {
                using (var client = new SmtpClient())
                {
                    System.Diagnostics.Debug.WriteLine($"Server: {_configuration["EmailSettings:ServerService"]}");
                    System.Diagnostics.Debug.WriteLine($"Port: {_configuration.GetValue<int>("EmailSettings:Port")}");
                    System.Diagnostics.Debug.WriteLine($"Email: {_configuration["EmailSettings:Email"]}");

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
                return response;
            }
        }
    }
}
