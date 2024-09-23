using EmojiHub_Backend.Dtos.EmojiList;
using EmojiHub_Backend.Dtos.User;
using EmojiHub_Backend.Models;

namespace EmojiHub_Backend.Dtos.Blog
{
    public class BlogDto
    {
        public string Description { get; set; } = string.Empty;
        public EmojiListDto EmojiList { get; set; }
    }
}
