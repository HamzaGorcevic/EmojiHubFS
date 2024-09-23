using System.Security.Claims;

namespace EmojiHub_Backend.Services
{

    public class BaseServices
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public BaseServices(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        
        public int GetUserIdFromToken()
        {
            var userID = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userID != null ? int.Parse(userID) : 0;

        }
    }
}
