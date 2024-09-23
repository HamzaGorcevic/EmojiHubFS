namespace EmojiHub_Backend.Models
{
    public class EmojiList
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public int? UserId { get; set; } 
        public User? User { get; set; }

    }
}
