namespace EmojiHub_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public ICollection<EmojiList> ?EmojiLists { get; set; } = new List<EmojiList>();
        public ICollection<Blog> ?Blogs { get; set; }= new List<Blog>(); 
    
    }
}
