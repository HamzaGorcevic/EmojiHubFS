namespace EmojiHub_Backend.Models
{
    public class ServiceResponse<T>
    {
        public T? Value { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool  Success { get; set; } = true;
    }
}
