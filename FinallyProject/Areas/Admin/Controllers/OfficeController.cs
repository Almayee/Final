using Bussiness.Exceptions;
using Bussiness.Services.Abstracts;
using Bussiness.Services.Concretes;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinallyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class OfficeController : Controller
    {
        private readonly IOfficeService _officeService;
        public OfficeController(IOfficeService officeService)
        {
                _officeService = officeService;
        }
        public IActionResult Index()
        {
            var offices =_officeService.GetAllOffices();
            return View(offices);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Office office)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _officeService.AddOffice(office);
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
            var existOffice = _officeService.GetOffice(x => x.Id == id);
            if (existOffice == null)
                return View("Error");
            return View(existOffice);
        }
        [HttpPost]
        public IActionResult Update(Office office)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _officeService.UpdateOffice(office, office.Id);
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
            var existOffice = _officeService.GetOffice(x => x.Id == id);
            if (existOffice == null)
                return View("Error");
            return View(existOffice);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
                _officeService.DeleteOffice(id);
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
