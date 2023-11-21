using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodebitsBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
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
