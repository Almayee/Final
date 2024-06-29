
using Bussiness.Services.Abstracts;
using Core.Models;
using FinallyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.AccessControl;

namespace FinallyProject.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ISliderService _sliderService;

        public HomeController(ISliderService sliderService)
        {
            _sliderService= sliderService;
        }

        public IActionResult Index()
        {
            
            var sliders =_sliderService.GetAllSliders();
            

            HomeVM homeVM = new HomeVM()
            {
                Sliders=sliders
            };

            return View(homeVM);
        }


    }
}
