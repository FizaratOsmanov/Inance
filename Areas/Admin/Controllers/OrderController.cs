using Inance.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inance.Models;
namespace Inance.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly InanceDBContext _dbContext;
        public OrderController(InanceDBContext inanceDBContext)
        {
            _dbContext = inanceDBContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Orders>? orders = _dbContext.Orders.ToList();
            return View(orders);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Orders order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            _dbContext.Orders.Add(order); 
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
