using CodebitsBlog.Areas.Admin.Models;

namespace CodebitsBlog.Repositories.Interface
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllComment();
        Task<Comment> GetCommentById(string id);
        Task<Comment> CreateComment(Comment Comment);
        Task<Comment> UpdateComment(Comment Comment);
        Task DeleteComment(string id);
    }
}
