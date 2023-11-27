using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "Lifestyle")]    
    public class LifestyleViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
