using EmojiHub_Backend.Dtos.Blog;
using EmojiHub_Backend.Models;

namespace EmojiHub_Backend.Services
{
    public interface IBlogService
    {
        public Task<ServiceResponse<List<BlogDto>>> GetAllBlogs();

        public Task<ServiceResponse<List<BlogDto>>> GetBlogs(); 
        public Task<ServiceResponse<BlogDto>>GetBlog(int blogId);
        public Task<ServiceResponse<int>> CreateBlog(BlogDto blog);
    }
}
