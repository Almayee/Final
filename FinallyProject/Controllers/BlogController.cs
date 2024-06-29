using Microsoft.AspNetCore.Mvc;

namespace FinallyProject.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
