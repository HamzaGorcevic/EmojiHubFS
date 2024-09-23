using AutoMapper;
using EmojiHub_Backend.Dtos.Blog;
using EmojiHub_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EmojiHub_Backend.Services
{
    public class BlogService : BaseServices,IBlogService
    {
        private IMapper _mapper;
        private DataContext _context;
        public BlogService(IHttpContextAccessor httpContextAccessor,IMapper mapper,DataContext context) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _context = context; 
        }

        public async Task<ServiceResponse<int>> CreateBlog(BlogDto blogDto)
        {
            var response = new ServiceResponse<int>();
            var userId = GetUserIdFromToken();
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
            {
                response.Success = false;
                response.Message = $"Error: User with Id {userId} does not exist.";
                return response;
            }

        
            // Create the Blog
            var blog = _mapper.Map<Blog>(blogDto);
            blog.UserId = userId; // Assign UserId for the Blog

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync(); // Save the Blog

            response.Success = true;
            response.Value = blog.Id; // Return the Blog ID
            return response;
        }



        public async Task<ServiceResponse<List<BlogDto>>> GetAllBlogs()
        {
            var response = new ServiceResponse<List<BlogDto>>();
            var blogs= await _context.Blogs.ToListAsync();
            response.Value = _mapper.Map<List<BlogDto>>(blogs);
            response.Success =blogs.Count > 0;
            return response;

        }

        public async Task<ServiceResponse<BlogDto>> GetBlog(int blogId)
        {
            var response = new ServiceResponse<BlogDto>();

            // Find the blog by its ID
            var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blogId);

            if (blog != null)
            {
                response.Value = _mapper.Map<BlogDto>(blog);
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Blog not found.";
            }

            return response;
        }


        public async Task<ServiceResponse<List<BlogDto>>> GetBlogs()
        {
            var response = new ServiceResponse<List<BlogDto>>();
            int userId = GetUserIdFromToken(); // Get the current user's ID

            // Retrieve all blogs created by the current user
            var blogs = await _context.Blogs.Where(b => b.UserId == userId).ToListAsync();

            if (blogs.Count > 0)
            {
                response.Value = _mapper.Map<List<BlogDto>>(blogs);
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "No blogs found for this user.";
            }

            return response;
        }

    }
}
