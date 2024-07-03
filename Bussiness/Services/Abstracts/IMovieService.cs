using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstracts
{
    public interface IMovieService
    {
        Task AddMovie(Film movie);
        void UpdateMovie(Film newMovie, int id);
        void DeleteMovie(int id);
        Film GetMovie(Func<Film, bool>? predicate = null);
        List<Film> GetAllMovies(Func<Film, bool>? predicate = null);
    }
}
