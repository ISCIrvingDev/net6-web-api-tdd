using Microsoft.AspNetCore.Mvc;

namespace WebApiTDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        //private readonly ILogger<UsersController> _logger;

        public UsersController(/*ILogger<UsersController> logger*/)
        {
            //_logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult Get()
        {
            return Ok("It's OK");
        }
    }
}