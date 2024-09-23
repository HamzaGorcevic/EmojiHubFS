using EmojiHub_Backend.Dtos.User;
using EmojiHub_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmojiHub_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]

        public async Task<ServiceResponse<int>>Register(RegisterUserDto user)
        {
            var response = await _authRepository.Register(user);
            return response;
        }

        [HttpPost("login")]
        public async Task<ServiceResponse<string>>Login(LoginUserDto user)
        {
            var response = await _authRepository.Login(user);    
            return response;
        }

        
    }
}
