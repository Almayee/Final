using Bussiness.Exceptions;
using Bussiness.Services.Abstracts;
using Bussiness.Services.Concretes;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinallyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //
    //
    //[Authorize(Roles = "SuperAdmin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            var slider = _sliderService.GetAllSliders();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _sliderService.AddSlider(slider);
            }
            catch (ImageContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileNullReferenceException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);
            if (existSlider == null)
                return View("Error");
            return View(existSlider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _sliderService.UpdateSlider(slider,slider.Id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound("Error");
            }
            catch (ImageContentTypeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Bussiness.Exceptions.FileNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var existSlider = _sliderService.GetSlider(x => x.Id == id);
            if (existSlider == null)
                return View("Error");
            return View(existSlider);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
                _sliderService.DeleteSlider(id);
            }
            catch (EntityNotFoundException ex)
            {
                return View("Error");
            }
            catch (Bussiness.Exceptions.FileNotFoundException ex)
            {
                return View("Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
