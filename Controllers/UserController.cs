using backend_app.Service;
using BackendApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;
        public UserController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAsync()
        {
            var users =  await _usersService.GetAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}