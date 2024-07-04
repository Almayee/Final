using Bussiness.Exceptions;
using Bussiness.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinallyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "SuperAdmin")]
    public class MovieController : Controller
    {
        private readonly IFilmService _filmService;
        public MovieController(IFilmService filmService)
        {
                _filmService = filmService;
        }
        public IActionResult Index()
        {
           var movies = _filmService.GetAllFilms();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _filmService.AddFilm(film);
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
            var existFilm = _filmService.GetFilm(x => x.Id == id);
            if (existFilm == null)
                return View("Error");
            return View(existFilm);
        }
        [HttpPost]
        public IActionResult Update(Film film)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _filmService.UpdateFilm(film, film.Id);
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
            var existMovie = _filmService.GetFilm(x => x.Id == id);
            if (existMovie == null)
                return View("Error");
            return View(existMovie);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
                _filmService.DeleteFilm(id);
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
