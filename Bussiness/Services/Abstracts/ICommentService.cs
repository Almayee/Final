using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstracts
{
    public interface ICommentService
    {
        void AddComment(int movieId, Comment comment);
    }
}
