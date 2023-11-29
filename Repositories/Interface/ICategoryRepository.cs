using CodebitsBlog.Areas.Admin.Models;

namespace CodebitsBlog.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(string id);
        Task<Category> CreateCategory(Category Category);
        Task<Category> UpdateCategory(Category Category);
        Task DeleteCategory(string id);
    }
}
