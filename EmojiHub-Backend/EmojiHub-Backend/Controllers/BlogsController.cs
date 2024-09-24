using EmojiHub_Backend.Dtos.Blog;
using EmojiHub_Backend.Models;
using EmojiHub_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmojiHub_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BlogsController
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {

            _blogService = blogService;

        }

        [HttpGet("allblogs")]
        public async Task<ServiceResponse<List<PublicBlogDto>>> GetAllBlogs()
        {
            var response = await _blogService.GetAllBlogs();
            return response;
        }
        [HttpGet("alluserblogs")]
        public async Task<ServiceResponse<List<BlogDto>>> GetUserBlogs()
        {
            var response = await _blogService.GetBlogs();
            return response;
        }
        [HttpPost("createblog")]
        public async Task<ServiceResponse<int>> CreateBlog(BlogDto blog
            )
        {
            var response = await _blogService.CreateBlog(blog);
            return response;
        }

    }
}
