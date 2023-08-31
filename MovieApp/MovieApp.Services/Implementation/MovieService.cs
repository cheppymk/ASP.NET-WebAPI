using MovieApp.DataAccess;
using MovieApp.DataAccess.Implementation;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;
using MovieApp.DTOs;
using MovieApp.Helpers;
using MovieApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieContext;
        public MovieService(IMovieRepository movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task AddMovieAsync(AddMovieDto addMovieDto)
        {
            Movie movieEntity = addMovieDto.ToMovie();
           await  _movieContext.AddAsync(movieEntity);
            
        }

        public async Task DeleteMovieAsync(int id)
        {
            Movie movieEntity = await  _movieContext.GetByIdAsync(id);

            if (movieEntity == null)
            {
                throw new ArgumentException($"Movie with id {id} not found");
            }

           await  _movieContext.DeleteAsync(movieEntity);
        }

        public async Task<List<MovieDto>> FilterMoviesAsync(int? year, Genre? genre)
        {
          
                if (genre.HasValue)
                {
                    
                    var enumValues = Enum.GetValues(typeof(Genre))
                                            .Cast<Genre>()
                                            .ToList();

                    if (!enumValues.Contains(genre.Value))
                    {
                        throw new Exception("Invalid genre value");
                    }
                }
            var filteredMovies = await _movieContext.FilterMoviesAsync(year, genre);
                return filteredMovies.Select(x => x.ToMovieDto()).ToList();
            }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieContext.GetAllAsync();
             return movies.Select(x => x.ToMovieDto()).ToList();
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var movieEntity = await _movieContext.GetByIdAsync(id);
            if (movieEntity == null)
            {
                throw new Exception("There is no such movie");
            }
            return movieEntity.ToMovieDto();
        }

        public async Task UpdateMovieAsync(UpdateMovieDto updateMovieDto)
        {
            var movieDb = await _movieContext.GetByIdAsync(updateMovieDto.Id);
           

            movieDb.Year = updateMovieDto.Year;
            movieDb.Title = updateMovieDto.Title;
            movieDb.Description = updateMovieDto.Description;
            movieDb.Genre = updateMovieDto.Genre;

           await _movieContext.UpdateAsync(movieDb);
        }

    }
    }

     
    
