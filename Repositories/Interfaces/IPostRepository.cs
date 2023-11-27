using CodebitsBlog.Areas.Admin.Models;

namespace CodebitsBlog.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<IList<Post>> GetAllPosts();
        Task<Post> GetPostById(string id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task DeletePost(string id);
    }
}
