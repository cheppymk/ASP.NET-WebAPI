using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dtos;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet] //api/movies
        public ActionResult<List<MovieDto>> Get()
        {
            try
            {
                var moviesDb = StaticDb.Movies;
                return Ok(moviesDb.Select(x => new MovieDto
                {
                    Description = x.Description,
                    Genre = x.Genre,
                    Title = x.Title,
                    Year = x.Year
                }));
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
        [HttpGet("{id}")] //api/movies/2
        public ActionResult<MovieDto> Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");
                }
                var movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == id);
                if (movieDb == null)
                {
                    return NotFound("Movie was not found");
                }
                return Ok(new MovieDto
                {
                    Description = movieDb.Description,
                    Title = movieDb.Title,
                    Genre = movieDb.Genre,
                    Year = movieDb.Year
                });
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
