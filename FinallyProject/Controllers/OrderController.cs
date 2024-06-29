using Microsoft.AspNetCore.Mvc;

namespace FinallyProject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
