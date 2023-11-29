using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.ViewModels;

namespace CodebitsBlog.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllPost();
    }
}
