using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.ViewModels;

namespace CodebitsBlog.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPosts(int pageNumber, int pageSize = 25);
        Task<IEnumerable<PostViewModel>> GetRecentPosts(int numOfPosts = 4);
        Task<IEnumerable<PostViewModel>> GetHeroSliderPosts(int numOfPosts = 4);
        Task<IEnumerable<PostViewModel>> GetPostsByCategoryName(string categoryName, int numOfPosts = 7);
        Task<PostViewModel> GetPostById(string id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task DeletePost(string id);
    }
}
