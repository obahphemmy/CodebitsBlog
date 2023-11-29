using CodebitsBlog.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "HeroSlider")]
    public class HeroSliderViewComponent : ViewComponent
    {
        private readonly IpostService _postService;

        public HeroSliderViewComponent(IpostService postService)
        {
            _postService = postService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var post = await _postService.GetHeroSliderPost();
            return View(post);
        }
    }
}
 