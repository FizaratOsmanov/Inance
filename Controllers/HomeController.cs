using Inance.DAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Inance.Controllers
{
    public class HomeController : Controller
    {
        readonly InanceDBContext _inanceDBContext;
        public HomeController(InanceDBContext inanceDBContext)
        {
            _inanceDBContext = inanceDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
