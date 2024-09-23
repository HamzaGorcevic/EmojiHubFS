using AutoMapper;
using EmojiHub_Backend.Dtos.Blog;
using EmojiHub_Backend.Dtos.EmojiList;
using EmojiHub_Backend.Dtos.User;
using EmojiHub_Backend.Models;
namespace EmojiHub_Backend
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();
            CreateMap<EmojiListDto, EmojiList>();
            CreateMap<EmojiList,EmojiListDto>();
            CreateMap<Blog,BlogDto>();
            CreateMap<BlogDto, Blog>();
        }

    }
}
