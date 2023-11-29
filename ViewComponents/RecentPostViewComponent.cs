using CodebitsBlog.Helpers;
using CodebitsBlog.Services;
using CodebitsBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPostViewComponent : ViewComponent
    {
        private readonly IpostService _service;
        private readonly UtilityService _utilityService;

        public RecentPostViewComponent(IpostService service, UtilityService utilityService)
        {
            _service = service;
            _utilityService = utilityService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _service.GetAllPost(1);
            foreach (var post in posts)
            {
                post.CoverImageUrl = _utilityService.GetProfileImagesRootPath() + "/" + post.CoverImageUrl;
            }

            return View(posts);
        }
    }
}
