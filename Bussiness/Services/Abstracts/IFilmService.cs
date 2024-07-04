using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstracts
{
    public interface IFilmService
    {
        Task AddFilm(Film film);
        void UpdateFilm(Film newFilm, int id);
        void DeleteFilm(int id);
        Film GetFilm(Func<Film, bool>? predicate = null);
        List<Film> GetAllFilms(Func<Film, bool>? predicate = null);
    }
}
