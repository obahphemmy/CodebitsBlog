using CodebitsBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace CodebitsBlog.Areas.Admin.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> LoginUser(string email, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser user, string password, string role = "User")
        {
            user.Id = Guid.NewGuid().ToString();
            user.UserRoleId = "2";

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                return result;
            } 
            return result;
        }
    }
}
