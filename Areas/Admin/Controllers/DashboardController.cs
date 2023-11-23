using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Areas.Admin.Services;
using CodebitsBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize]
	public class DashboardController : Controller
	{
        private readonly IUserService _userService;

        public DashboardController(IUserService userService)
        {
            _userService = userService;
        }

        
        public async Task<IActionResult> Index()
		{
			return View();
		}

        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = model.ReturnUrl ?? Url.Content("/admin/dashboard");

                var result = await _userService.LoginUser(model.Username, model.Password, model.RememberMe);

                if (result)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutUser();
            return RedirectToAction("Login", "Dashboard");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var profilePictureUrl = await _userService.UploadImage(model.UserProfilePicture);

                var applicationUser = new ApplicationUser
                {
                    Email = model.EmailAddress,
                    UserName = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName  = model.LastName,
                    ProfilePictureUrl = profilePictureUrl ?? "" 
                };

                var  result = await _userService.RegisterUser(applicationUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Dashboard");
                } 

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Post()
        {
            return View();
        }

        public async Task<IActionResult> Addpost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Addpost(Models.Post post)
        {
            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }

        [Authorize(Roles="User")]
        public async Task<IActionResult> Category()
        {
            return View();
        }
        public async Task<IActionResult> Comment()

        {
            return View();
        }
    }
}
