using Microsoft.AspNetCore.Mvc;

namespace SuperMarketManagement.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
