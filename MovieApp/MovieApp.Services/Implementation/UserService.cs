using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MovieApp.DataAccess;
using MovieApp.Domain.Models;
using MovieApp.DTOs;
using MovieApp.Services.Interfaces;
using MovieApp.Shared;
using MovieApp.Helpers;

namespace SEDC.MoviesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> AuthenticateAsync(LoginModelDto model)
        {
            var md5data = MD5.HashData(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = (await _userRepository.GetAllAsync())
                .SingleOrDefault(x => x.Username == model.Username && x.Password == hashedPassword);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                                                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userModel = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = tokenHandler.WriteToken(token),
                // Assuming ToMovieDto is an extension or a mapper you have
                MovieList = user.MovieList.Select(movie => movie.ToMovieDto()).ToList()
            };

            return userModel;
        }

        public async Task RegisterAsync(RegisterModelDto model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
                throw new UserException("First name is required");
            if (string.IsNullOrEmpty(model.LastName))
                throw new UserException("Last name is required");
            if (!await ValidUsernameAsync(model.Username))
                throw new UserException("Username is already in use");
            if (model.Password != model.ConfirmPassword)
                throw new UserException("Passwords did not match!");
            var md5data = MD5.HashData(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = hashedPassword
            };

            await _userRepository.AddAsync(user);
        }

        private async Task<bool> ValidUsernameAsync(string username)
        {
            return (await _userRepository.GetAllAsync()).All(x => x.Username != username);
        }
    }
}
