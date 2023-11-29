using CodebitsBlog.Helpers;
using CodebitsBlog.Services;
using CodebitsBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.ViewComponents
{
    [ViewComponent(Name = "Categories")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var category = await _categoryService.GetAllPost();
            var c = new CategoryViewModel
            {
                Categories = category
            };
            
            return View(c);
        }
    }
}
