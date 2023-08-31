using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movie entity)
        {
            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie entity)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movie>> FilterMoviesAsync(int? year, Genre? genre)
        {
            IQueryable<Movie> query = _context.Movies;

            if (year.HasValue)
            {
                query = query.Where(x => x.Year == year);
            }

            if (genre.HasValue)
            {
                query = query.Where(x => x.Genre == genre);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Movie update)
        {
            _context.Movies.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
