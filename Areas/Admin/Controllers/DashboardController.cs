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
    }
}
