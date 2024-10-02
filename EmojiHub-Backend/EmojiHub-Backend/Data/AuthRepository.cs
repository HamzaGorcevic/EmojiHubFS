using AutoMapper;
using EmojiHub_Backend.Dtos.User;
using EmojiHub_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmojiHub_Backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context,IMapper mapper,IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(LoginUserDto user)
        {
            User? LoggedUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            var response = new ServiceResponse<string>();
            if (LoggedUser != null)
            {
                response.Value = CreateToken(LoggedUser);
                response.Success = true;
                return response;
            }

            response.Success = false;

            response.Message = "User doesnt exist";

            return response;

        }

        public  async Task<ServiceResponse<int>> Register(RegisterUserDto user)
        {
            var response = new ServiceResponse<int>();
            User saveUser = _mapper.Map<User>(user);

            if (UserExists(saveUser))
            {
                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);


                saveUser.PasswordHash = passwordHash;
                saveUser.PasswordSalt = passwordSalt;
                _context.Users.Add(saveUser);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Value = 123;
                return response;
            }
            response.Success = false;
            response.Message = "User already exists";
            return response;


        }

        public bool UserExists(User user)
        {
            return _context.Users.FirstOrDefault(u=>u.Email == user.Email) == null;
        }

        public string CreateToken(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()));

            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Token").Value);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials

            };
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            

        }
    }
}
