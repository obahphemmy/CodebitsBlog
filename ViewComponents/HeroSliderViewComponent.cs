using CodebitsBlog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "HeroSlider")]
    public class HeroSliderViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public HeroSliderViewComponent(IPostService postService)
        {
            _postService = postService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _postService.GetHeroSliderPosts(4);
            return View(posts);
        }
    }
}
