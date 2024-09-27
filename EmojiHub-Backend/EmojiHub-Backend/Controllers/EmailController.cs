using EmojiHub_Backend.Models;
using EmojiHub_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmojiHub_Backend.Controllers
{
    [Route("[controller]")]
    public class EmailController
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendEmail")]
        public async Task<ServiceResponse<bool>> SendEmail([FromBody] Email email)
        {
            var response = await _emailService.SendEmail(email);
            return response;
        }
    }
}
