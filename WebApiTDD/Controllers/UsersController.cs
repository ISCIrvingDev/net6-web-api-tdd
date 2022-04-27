using Microsoft.AspNetCore.Mvc;
using WebApiTDD.Services;

namespace WebApiTDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        //private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;

        public UsersController(/*ILogger<UsersController> logger*/ IUsersService usersService)
        {
            //_logger = logger;
            _usersService = usersService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _usersService.GetAllUsers();

            if (users.Any()) return Ok(users);
            else return NotFound();
        }
    }
}