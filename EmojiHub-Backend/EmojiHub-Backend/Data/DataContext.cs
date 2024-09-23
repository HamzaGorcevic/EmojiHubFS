using EmojiHub_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EmojiHub_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<User>Users => Set<User>();
        public DbSet<EmojiList>EmojiLists => Set<EmojiList>();
        public DbSet<Blog>Blogs => Set<Blog>();      
    }
}
