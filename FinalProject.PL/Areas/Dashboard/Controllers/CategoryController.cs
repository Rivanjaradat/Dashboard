using Microsoft.AspNetCore.Mvc;

namespace FinalProject.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
