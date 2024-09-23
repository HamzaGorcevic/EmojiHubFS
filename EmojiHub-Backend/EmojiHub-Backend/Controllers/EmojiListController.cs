using EmojiHub_Backend.Dtos.EmojiList;
using EmojiHub_Backend.Models;
using EmojiHub_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmojiHub_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmojiListController : ControllerBase
    {
        private readonly IEmojiListService _emojiListService;

        public EmojiListController(IEmojiListService emojiListService)
        {
            _emojiListService = emojiListService;
        }

        [HttpGet("allemojilists")]
        public async Task<ServiceResponse<List<EmojiListDto>>> GetAllEmojiLists()
        {
            var response = await _emojiListService.GetAllEmojiLists();
            return response;
        }

        [HttpGet("alluseremojilists")]
        public async Task<ServiceResponse<List<EmojiListDto>>> GetUserEmojiLists()
        {
            var response = await _emojiListService.GetEmojiLists();
            return response;
        }

        [HttpGet("emojilist/{id}")]
        public async Task<ServiceResponse<EmojiListDto>> GetEmojiList(int id)
        {
            var response = await _emojiListService.GetEmojiList(id);
            return response;
        }

        [HttpPost("createemojilist")]
        public async Task<ServiceResponse<int>> CreateEmojiList(EmojiListDto emojiListDto)
        {
            var response = await _emojiListService.CreateEmojiList(emojiListDto);
            return response;
        }
    }
}
