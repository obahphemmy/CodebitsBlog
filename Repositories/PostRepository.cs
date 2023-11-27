using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Data;
using CodebitsBlog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodebitsBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Post> CreatePost(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task DeletePost(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
            }
        }

        public async Task<IList<Post>> GetAllPosts()
        {
            var posts = _dbContext.Posts.Include(p => p.Category).Include(p => p.User).ToList();
            return posts;
        }

        public async Task<Post> GetPostById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Posts.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException();
        }

        public async Task<Post> UpdatePost(Post post)
        {
            _dbContext.Posts.Update(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }
    }
}
