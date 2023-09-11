using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTOs;
using MovieApp.Services.Interfaces;
using MovieApp.Shared;
using System;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModelDto model)
        {
            try
            {
                var user = await _userService.AuthenticateAsync(model);

                if (user == null)
                {
                    return NotFound("Username or Password is incorrect!");
                }

                return Ok(user);
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDto model)
        {
            try
            {
                await _userService.RegisterAsync(model);
                return Ok(new ResponseDto() { success = "Successfully registered user!" });
            }
            catch (UserException ex)
            {
                return BadRequest(new ResponseDto() { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred!");
            }
        }
    }
}
