using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "HeroSlider")]
    public class HeroSliderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
