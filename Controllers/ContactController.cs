﻿using Microsoft.AspNetCore.Mvc;

namespace Inance.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
