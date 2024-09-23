using AutoMapper;
using EmojiHub_Backend.Dtos.EmojiList;
using EmojiHub_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EmojiHub_Backend.Services
{
    public class EmojiListService : BaseServices, IEmojiListService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EmojiListService(IHttpContextAccessor httpContextAccessor, IMapper mapper, DataContext context)
            : base(httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
        }

        // Create a new Emoji List
        public async Task<ServiceResponse<int>> CreateEmojiList(EmojiListDto emojiListDto)
        {
            var response = new ServiceResponse<int>();
            int userId = GetUserIdFromToken();  

            var emojiList = _mapper.Map<EmojiList>(emojiListDto);
            emojiList.UserId = userId; 

            _context.EmojiLists.Add(emojiList);
            await _context.SaveChangesAsync();

            response.Value = emojiList.Id;
            response.Success = true;
            return response;
        }

        // Get all emoji lists
        public async Task<ServiceResponse<List<EmojiListDto>>> GetAllEmojiLists()
        {
            var response = new ServiceResponse<List<EmojiListDto>>();
            var emojiLists = await _context.EmojiLists.ToListAsync();

            response.Value = _mapper.Map<List<EmojiListDto>>(emojiLists);
            response.Success = emojiLists.Count > 0;
            return response;
        }

        // Get a specific emoji list by ID
        public async Task<ServiceResponse<EmojiListDto>> GetEmojiList(int emojiListId)
        {
            var response = new ServiceResponse<EmojiListDto>();

            var emojiList = await _context.EmojiLists.FirstOrDefaultAsync(e => e.Id == emojiListId);

            if (emojiList != null)
            {
                response.Value = _mapper.Map<EmojiListDto>(emojiList);
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Emoji list not found.";
            }

            return response;
        }

        // Get all emoji lists for the current user
        public async Task<ServiceResponse<List<EmojiListDto>>> GetEmojiLists()
        {
            var response = new ServiceResponse<List<EmojiListDto>>();
            int userId = GetUserIdFromToken();  // Get the current user's ID

            var emojiLists = await _context.EmojiLists.Where(e => e.UserId == userId).ToListAsync();

            if (emojiLists.Count > 0)
            {
                response.Value = _mapper.Map<List<EmojiListDto>>(emojiLists);
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "No emoji lists found for this user.";
            }

            return response;
        }
    }
}
