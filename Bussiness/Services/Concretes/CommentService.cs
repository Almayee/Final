using Bussiness.Services.Abstracts;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly List<Film> _movies;
        public CommentService()
        {
            _movies = new List<Film>
            {
                new Film { Id = 1, Title = "Movie 1", Description = "Description 1" },
                new Film { Id = 2, Title = "Movie 2", Description = "Description 2" }
            };
        }
        public void AddComment(int movieId, Comment comment)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null)
            {
                comment.MovieId = movieId;
                comment.CreatedAt = DateTime.Now;
                comment.Id = movie.Comments.Count + 1;
                movie.Comments.Add(comment);
            }
        }
       
    }
}
