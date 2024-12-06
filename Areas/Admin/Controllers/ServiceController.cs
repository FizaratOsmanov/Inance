using Inance.Areas.Admin.ViewModels;

using Inance.DAL;
using Inance.DTOs.ServiceDTOs;
using Inance.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Inance.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly InanceDBContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(InanceDBContext inanceDBContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = inanceDBContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Services> GetAllServices()
        {
            IEnumerable<Services> services = _dbContext.Services;
            return services;
        }

        public IActionResult Index()
        {
            IEnumerable<Services>? services = _dbContext.Services.ToList();
            return View(services);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCreateVM serviceCreateVM)
        {
            if (serviceCreateVM.Img is null)
            {
                return View(serviceCreateVM);
            }
            if (!ModelState.IsValid)
            {
                return View(serviceCreateVM);
            }
            string fileName = Path.GetFileNameWithoutExtension(serviceCreateVM.Img.FileName);
            if (serviceCreateVM.Img.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("Img", "Fayl cox boyukdur.");
                return View(serviceCreateVM);
            }
            string[] allowedFormat = [".jpg", ".png", ".jpeg", ".svg", ".webp"];
            string extension = Path.GetExtension(serviceCreateVM.Img.FileName);
            bool isAllowed = false;
            foreach (var format in allowedFormat)
            {
                if (format == extension)
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed)
            {
                ModelState.AddModelError("Img", "Icaze yoxdur");
                return View(serviceCreateVM);
            }
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "ServicePhotos");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            if (Path.Exists(Path.Combine(uploadPath, fileName + extension)))
            {
                fileName = fileName + Guid.NewGuid().ToString();
            }
            fileName = fileName + extension;
            uploadPath = Path.Combine(uploadPath, fileName);
            using FileStream fileStream = new FileStream(uploadPath, FileMode.Create);
            serviceCreateVM.Img.CopyToAsync(fileStream);
            Services service = new Services()
            {
                Image = fileName
            };

            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Services? services=_dbContext.Services.Include(s=>s.Image)
                        .FirstOrDefault(s => s.Id==id);

            if (services == null)
            {
                return RedirectToAction(nameof(Index), nameof(services));
            }

            UpdateServiceDto updateServiceDto=new UpdateServiceDto()
            {
                Title=services.Title,
                Description=services.Description,
                MainImageUrl=services.
                
            }



        }
        
        [HttpPost]
        public void UpdateService(int id, Services services)
        {
            Services? baseService = _dbContext.Services.Find(id);
            baseService.Title = services.Title;
            baseService.Description = services.Description;
            baseService.IsActive = services.IsActive;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {


            Services? services = _dbContext.Services.Find(id);
            if (services is null)
            {
                throw new Exception($"Slider Item not found with this id({id})");
            }

            _dbContext.Services.Remove(services);
        }
    }
}
