using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "PostGrid")]
    public class PostGridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
