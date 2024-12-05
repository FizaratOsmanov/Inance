using Microsoft.AspNetCore.Mvc;

namespace Inance.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
