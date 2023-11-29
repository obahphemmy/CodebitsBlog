using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Repositories.Interface;

namespace CodebitsBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<IEnumerable<Category>> GetAllPost()
        {
            var categories = _categoryRepository.GetAllCategory();
            return categories;
        }
    }
}
