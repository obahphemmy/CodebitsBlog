using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Repositories.Interface;
using CodebitsBlog.ViewModels;

namespace CodebitsBlog.Services
{
    public class PostService : IpostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Post> CreatePost(Post post)
        {
            return await _postRepository.CreatePost(post);
        }

        public async Task DeletePost(string id)
        {
            await _postRepository.DeletePost(id);
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPost(int pageNumber, int pageSize = 25)
        {
            var post = await _postRepository.GetAllPost();
            return post.OrderByDescending(x => x.CreatedOn).Select(post => new PostViewModel
            {
                PostId = post.Id,
                Title = post.Title,
                PostAuthor = $"{post.User.FirstName} {post.User.LastName}",
                Body = post.Body,
                Category = post.Category.Name,
                CoverImageUrl = post.CoverImageUrl,
                PostAuthorImageUrl = post.User.ProfilePictureUrl,
                PostDate = post.CreatedOn.ToString(),
                PostExtract = post.Body.Substring(0, 100)
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<IEnumerable<PostViewModel>> GetHeroSliderPost(int size = 4)
        {
            var post = await _postRepository.GetAllPost();

            return post.Where(x => x.IsFeatured == true).Take(size).Select(y => new PostViewModel
            {
                PostId = y.Id,
                Title = y.Title,
                PostAuthor = $"{y.User.FirstName} {y.User.LastName}",
                Body = y.Body,
                Category = y.Category.Name,
                CoverImageUrl = y.CoverImageUrl,
                PostAuthorImageUrl = y.User.ProfilePictureUrl,
                PostDate = y.CreatedOn.ToString(),
                PostExtract = y.Body
            }).ToList();
        }

        public async Task<IList<PostViewModel>> GetPostByCategoryName(string category, int numberOfPost = 7)
        {
            var post = await _postRepository.GetAllPost();
            return post.Where(x => x.Category.Name.ToLower() == category.ToLower()).Take(numberOfPost).Select(y => new PostViewModel
            {
                PostId = y.Id,
                Title = y.Title,
                PostAuthor = $"{y.User.FirstName} {y.User.LastName}",
                Body = y.Body,
                Category = y.Category.Name,
                CoverImageUrl = y.CoverImageUrl,
                PostAuthorImageUrl = y.User.ProfilePictureUrl,
                PostDate = y.CreatedOn.ToString(),
                PostExtract = y.Body.Substring(0, 100)
            }).ToList();
        }

        public Task<PostViewModel> GetPostById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostViewModel>> GetRecentPost(int size = 4)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
