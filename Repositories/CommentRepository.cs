using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Data;
using CodebitsBlog.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CodebitsBlog.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> CreateComment(Comment Comment)
        {
            _dbContext.Comments.Add(Comment);
            await _dbContext.SaveChangesAsync();
            return Comment;
        }

        public async Task DeleteComment(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new NotImplementedException(nameof(id));
            }
            var comment = _dbContext.Comments.FirstOrDefault(p => p.Id == id);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
            }
        }

        public async Task<IEnumerable<Comment>> GetAllComment()
        {
            var comments = _dbContext.Comments.ToList();
            return comments;
        }

        public async Task<Comment> GetCommentById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _dbContext.Comments.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException();
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
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
                throw new NotImplementedException(nameof(id));
            }
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
            }
        }
    }
}
