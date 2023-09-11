using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Domain.Enums;
using MovieApp.DTOs;
using MovieApp.Services.Interfaces;
using System.Security.Cryptography;

namespace MovieApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await _movieService.GetAllMoviesAsync();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("You must provide a valid id");
                }

                var movies = await _movieService.GetMovieByIdAsync(id);

                if (movies == null)
                {
                    NotFound("the movie you were looking for its not found");
                }
                return Ok(movies);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin");

            }

        }

        [HttpPost]

        public async Task<IActionResult> CreateMovieAsync([FromBody] AddMovieDto addMoviedto)
        {
            try
            {
                if (addMoviedto == null)
                {
                    BadRequest("fill up the form");
                }

                await _movieService.AddMovieAsync(addMoviedto);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin");
            }
        }

        [HttpPatch("{id}")]

        public async Task<IActionResult> UpdateMovieAsync([FromBody] UpdateMovieDto updateMovieDto, int id)
        {
            try
            {
                if (updateMovieDto.Id <= 0 || updateMovieDto.Title == null || updateMovieDto.Year == 0 || updateMovieDto.Genre == null || updateMovieDto.Description == null)
                {
                    return BadRequest("Invalid update");
                }

                await _movieService.UpdateMovieAsync(updateMovieDto);

                return Ok("Movie updated successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin");
            }








        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                await _movieService.DeleteMovieAsync(id);
                return Ok("Movie deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin");
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterMovies(int? year, Genre? genre)
        {
            try
            {
                var movies = await _movieService.FilterMoviesAsync(year, genre);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, contact the admin");
            }

        }
    }
}
