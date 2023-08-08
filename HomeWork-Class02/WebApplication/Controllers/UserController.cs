using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllUsers()
        {
            return Ok(StaticDb.users);
        }
        [HttpGet("{id}")]
        public ActionResult<string> GetUser(int id)
        {
            if (id < 0 || id >= StaticDb.users.Count)
                return NotFound("User not found");

            return Ok(StaticDb.users[id]);
        }

    }
}
