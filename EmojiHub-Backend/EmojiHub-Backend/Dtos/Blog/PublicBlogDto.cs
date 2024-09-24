using EmojiHub_Backend.Dtos.EmojiList;

namespace EmojiHub_Backend.Dtos.Blog
{
    public class PublicBlogDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EmojiListDto EmojiList { get; set; }
    }
}
