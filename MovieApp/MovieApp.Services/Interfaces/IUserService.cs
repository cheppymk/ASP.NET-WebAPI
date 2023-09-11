using MovieApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AuthenticateAsync(LoginModelDto model);
        Task RegisterAsync(RegisterModelDto model);
    }
}
