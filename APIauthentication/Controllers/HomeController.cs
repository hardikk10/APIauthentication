using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using Microsoft.AspNetCore.Mvc;


namespace AuthenticationAPI.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly Services _services;

        public HomeController(Services services)
        {
            _services = services;
        }


        [HttpPost("login")]
        public IActionResult login([FromBody] userLogin userLogin)
        {
            return Ok(_services.jwtTokenGeneration(userLogin));
        }
    }
}
