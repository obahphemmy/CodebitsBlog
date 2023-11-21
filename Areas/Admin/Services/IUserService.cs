using CodebitsBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace CodebitsBlog.Areas.Admin.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(ApplicationUser user, string password, string role = "User");
        Task<IdentityResult> LoginUser(string email, string password, bool rememberMe);
    }
}
