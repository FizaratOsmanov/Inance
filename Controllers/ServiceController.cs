using Microsoft.AspNetCore.Mvc;

namespace Inance.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
