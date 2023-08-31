using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> FilterMoviesAsync(int? year, Genre? genre);
    }
}
