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
        Task AddMovie(Movie movie);
        void UpdateMovie(Movie newMovie, int id);
        void DeleteMovie(int id);
        Movie GetMovie(Func<Movie, bool>? predicate = null);
        List<Movie> GetAllMovies(Func<Movie, bool>? predicate = null);
    }
}
