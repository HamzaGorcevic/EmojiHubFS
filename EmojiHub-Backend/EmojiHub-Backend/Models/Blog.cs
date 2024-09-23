namespace EmojiHub_Backend.Models
{
    public class Blog
    {
        public int Id { get; set; } 
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }
        public int EmojiListId { get; set; }    
        public EmojiList EmojiList { get; set; }
       
    }
}
