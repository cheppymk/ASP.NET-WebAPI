using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsername(string username);

        Task<User> LoginUser(string username, string hashedPassword);
    }
}
