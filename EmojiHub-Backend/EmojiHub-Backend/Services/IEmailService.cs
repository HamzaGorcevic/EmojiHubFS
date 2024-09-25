using EmojiHub_Backend.Models;

namespace EmojiHub_Backend.Services
{
    public interface IEmailService
    {

        public Task<ServiceResponse<bool>> SendEmail(Email email);
    }
}
