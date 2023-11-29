using CodebitsBlog.Areas.Admin.Models;

namespace CodebitsBlog.Repositories.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPost();
        Task<Post> GetPostById(string id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task DeletePost(string id);
    }
}
