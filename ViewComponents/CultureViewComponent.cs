using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "Culture")]
    public class CultureViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
