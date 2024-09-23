using EmojiHub_Backend.Dtos.EmojiList;
using EmojiHub_Backend.Models;

namespace EmojiHub_Backend.Services
{
    public interface IEmojiListService

    {
        Task<ServiceResponse<List<EmojiListDto>>> GetAllEmojiLists();

        Task<ServiceResponse<List<EmojiListDto>>> GetEmojiLists();
        Task<ServiceResponse<EmojiListDto>> GetEmojiList(int emojiListId);
        Task<ServiceResponse<int>> CreateEmojiList(EmojiListDto emojiListDto);
    }
}
