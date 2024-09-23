using EmojiHub_Backend.Dtos.Blog;
using EmojiHub_Backend.Dtos.EmojiList;

namespace EmojiHub_Backend.Dtos.User
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public ICollection<EmojiListDto> EmojiLists { get; set; } = new List<EmojiListDto>();
        public ICollection<BlogDto> Blogs { get; set; } = new List<BlogDto>();

    }
}
