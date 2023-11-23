using CodebitsBlog.Areas.Admin.Models;
using CodebitsBlog.Areas.Admin.Services;
using CodebitsBlog.Areas.Admin.ViewModels;
using CodebitsBlog.Data;
using CodebitsBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodebitsBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
	public class DashboardController : Controller
	{
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext;

        public DashboardController(IUserService userService,
            ApplicationDbContext dbContext)
        {
            _userService = userService;
            _dbContext = dbContext;
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
            var categories = await _dbContext.Categories.ToListAsync();

            var model = new PostViewModel
            {
                Categories = categories,
                UserId = await _userService.GetCurrentUserId(User)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Addpost(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = model.Title,
                    Body = model.Body,
                    CategoryId = model.CategoryId,
                    UserId = model.UserId
                };

                await _dbContext.Posts.AddAsync(post);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("CategoryList", "Dashboard");
            }
            return View(model);
        }

        public async Task<IActionResult >Category()
        {
            return View();
        }
        public async Task<IActionResult> Comment()

        {
            return View();
        }
        public async Task<IActionResult> Profile()

        {
            return View();
        }
        public async Task<IActionResult> CategoryList()

        {
            return View();
        }

        public async Task<IActionResult> EditProfile()

        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Users()

        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser()

        {
            return View();
        }


    }
}
