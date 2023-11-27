using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Repositories.Interfaces;
using CodebitsBlog.ViewModels;

namespace CodebitsBlog.Services
{
    public class PostService : IPostService
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

        public async Task<IEnumerable<PostViewModel>> GetAllPosts(int pageNumber, int pageSize = 25)
        {
            var posts = await _postRepository.GetAllPosts();
            return posts.Select(post => new PostViewModel
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

        public async Task<IEnumerable<PostViewModel>> GetPostsByCategoryName(string categoryName, int numOfPosts = 7)
        {
            var posts = await _postRepository.GetAllPosts();
            return posts
                .Where(x => x.Category.Name.ToLower() == categoryName.ToLower())
                .Take(numOfPosts)
                .Select(y => new PostViewModel
                    {
                        Body = y.Body,
                        Category = y.Category.Name,
                        CoverImageUrl= y.CoverImageUrl,
                        PostAuthor = $"{y.User.FirstName} {y.User.LastName}",
                        PostAuthorImageUrl= y.User.ProfilePictureUrl,
                        PostDate= y.CreatedOn.ToString(),
                        PostExtract = y.Body.Substring(0, 100),
                        PostId = y.Id,
                        Title = y.Title
                    }).ToList();    
        }
        public async Task<IEnumerable<PostViewModel>> GetHeroSliderPosts(int numOfPosts = 4)
        {
            var posts = await _postRepository.GetAllPosts();

            return posts.OrderByDescending(x => x.CreatedOn)
                .Take(numOfPosts)
                .Select(y => new PostViewModel
                {
                    Body = y.Body,
                    Category = y.Category.Name,
                    CoverImageUrl = y.CoverImageUrl,
                    PostAuthor = $"{y.User.FirstName} {y.User.LastName}",
                    PostAuthorImageUrl = y.User.ProfilePictureUrl,
                    PostDate = y.CreatedOn.ToString(),
                    PostExtract = y.Body,
                    PostId = y.Id,
                    Title = y.Title
                }).ToList();
        }

        public Task<PostViewModel> GetPostById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostViewModel>> GetRecentPosts(int numOfPosts = 4)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
