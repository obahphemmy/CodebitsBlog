using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "Business")]
    public class BusinessViewComponent : ViewComponent
    {        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
