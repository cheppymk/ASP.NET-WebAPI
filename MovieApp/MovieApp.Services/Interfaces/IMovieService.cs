using MovieApp.Domain.Enums;
using MovieApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMoviesAsync();
        Task<List<MovieDto>> FilterMoviesAsync(int? year, Genre? genre);
        Task<MovieDto> GetMovieByIdAsync(int id);
        Task AddMovieAsync(AddMovieDto addMovieDto);
        Task UpdateMovieAsync(UpdateMovieDto updateMovieDto);
        Task DeleteMovieAsync(int id);




    }
}
