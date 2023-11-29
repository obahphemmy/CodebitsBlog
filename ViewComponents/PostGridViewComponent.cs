using CodebitsBlog.Helpers;
using CodebitsBlog.Services;
using CodebitsBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "PostGrid")]
    public class PostGridViewComponent : ViewComponent
    {
        private readonly IpostService _service;
        private readonly UtilityService _utilityService;

        public PostGridViewComponent(IpostService service, UtilityService utilityService)
        {
            _service = service;
            _utilityService = utilityService;
        }

        public UtilityService UtilityService { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _service.GetAllPost(1);
            var gridPosts = new Dictionary<string, IEnumerable<PostViewModel>>();
            gridPosts.Add("grid1", posts.Skip(1).Take(3));
            gridPosts.Add("grid2", posts.Skip(4).Take(3));
            var p =  new PostGridViewModel
            {
                EntryPost = posts.FirstOrDefault(),
                GridPosts = gridPosts,
                rootPath = _utilityService.GetProfileImagesRootPath(operationType: false) + "/"
            };
            return View(p);
        }
    }
}
