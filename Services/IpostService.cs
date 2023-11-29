using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.ViewModels;

namespace CodebitsBlog.Services
{
    public interface IpostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPost(int pageNumber, int page = 25);
        Task<IEnumerable<PostViewModel>> GetRecentPost(int size = 4);
        Task<IEnumerable<PostViewModel>> GetHeroSliderPost(int size = 4);
        Task<IList<PostViewModel>> GetPostByCategoryName(string category, int numberOfPost = 7);
        Task<PostViewModel> GetPostById(string id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task DeletePost(string id);
    }
}
