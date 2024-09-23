using EmojiHub_Backend.Dtos.User;
using EmojiHub_Backend.Models;

namespace EmojiHub_Backend.Data
{
    public interface IAuthRepository
    {
        public Task<ServiceResponse<int>> Register(RegisterUserDto user);
        public Task<ServiceResponse<string>> Login(LoginUserDto user);
        
    }
}
