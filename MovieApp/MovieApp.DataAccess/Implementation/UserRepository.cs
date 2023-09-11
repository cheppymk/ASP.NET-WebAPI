using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _context;
        public UserRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(x => x.MovieList).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUser(string username, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User update)
        {
            _context.Users.Update(update);
            await _context.SaveChangesAsync();
        }
    }
}
