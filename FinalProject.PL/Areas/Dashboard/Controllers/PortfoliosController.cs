using AutoMapper;
using FinalProject.DAL.Data;
using FinalProject.DAL.Data.Models;
using FinalProject.PL.Areas.Dashboard.ViewModels;
using FinalProject.PL.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class PortfoliosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PortfoliosController(ApplicationDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
           
          
            return View(mapper.Map<IEnumerable<ServicesVM>>(context.Services.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImageName = FilesSettings.UploadFile(vm.Image, "images");

            var service=mapper.Map<Service>(vm);
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = context.Services.Find(id);
            if (service == null)
            {
                return NotFound();

            }
            var serviceModel=mapper.Map<ServiceDetailsVM>(service);
            return View(serviceModel);

        }
        
        [HttpPost]
    
        public IActionResult DeleteConfirmed(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));

            }
            context.Services.Remove(service);
            context.SaveChanges();
            return Ok( new {message="service deleted"});

        }
        [HttpGet]
        public IActionResult Edit (int id )
        {
            var service = context.Services.Find( id);
            if (service is null)
            {
                return NotFound();
            }
            var servicesVm=mapper.Map<ServiceFormVM>(service);
            return View(servicesVm);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (ServiceFormVM vm)

        {
            var service = context.Services.Find(vm.Id);
            if (service is null)
            {
                return NotFound();
            }
            if (vm.Image is null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSettings.DeleteFile(service.ImageName, "images");
                vm.ImageName = FilesSettings.UploadFile(vm.Image, "images");

            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
           
                    mapper.Map(vm,service);
            context.SaveChanges();
            return RedirectToAction(nameof (Index));

        }
    }
}
