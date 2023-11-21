using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Areas.Admin.Services;
using CodebitsBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
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

        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser
                {
                    Email = model.EmailAddress,
                    UserName = model.EmailAddress,
                    FirstName = model.FirstName,
                    LastName  = model.LastName,
                    ProfilePictureUrl = ""  
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

        public async Task<IActionResult> Addedpost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Addedpost(Post post)
        {
            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }
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
