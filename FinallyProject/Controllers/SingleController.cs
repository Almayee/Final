using Microsoft.AspNetCore.Mvc;

namespace FinallyProject.Controllers
{
    public class SingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
