using CodebitsBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
        [Authorize]
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

        public async Task<IActionResult> VPost()
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
    }
}
