using Bussiness.Exceptions;
using Bussiness.Extensions;
using Bussiness.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concretes
{
    public class MovieService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IWebHostEnvironment _env;
        public MovieService(IFilmRepository filmRepository, IWebHostEnvironment env)
        {
            _env = env;
            _filmRepository = filmRepository;
        }

        public async Task AddFilm(Film film)
        {
            if (film.ImageFile == null)
                throw new Exceptions.FileNotFoundException("The file cannot be empty!");

            film.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\movies", film.ImageFile);

            await _filmRepository.AddAsync(film);
            await _filmRepository.CommitAsync();
        }
    

    public void DeleteFilm(int id)
    {
        var existFilm = _filmRepository.Get(x => x.Id == id);
        if (existFilm == null)
            throw new EntityNotFoundException("File not found!");

        Helper.DeleteFIle(_env.WebRootPath, @"uploads\movies", existFilm.ImageUrl);

        _filmRepository.Delete(existFilm);
        _filmRepository.Commit();

    }

    public List<Film> GetAllFilms(Func<Film, bool>? predicate = null)
    {
            return _filmRepository.GetAll(predicate);
        }

    public Film GetFilm(Func<Film, bool>? predicate = null)
    {
            return _filmRepository.Get(predicate);
        }

    public void UpdateFilm(Film newFilm, int id)
    {
            var oldFilm = _filmRepository.Get(x => x.Id == id);

               if (oldFilm == null)
                   throw new EntityNotFoundException("File not found!");

                if (newFilm.ImageFile != null)
                {
                    Helper.DeleteFIle(_env.WebRootPath, @"uploads\movies", oldFilm.ImageUrl);
                    oldFilm.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\movies", newFilm.ImageFile);
                }

                _filmRepository.Commit();
        }
    }  
}
