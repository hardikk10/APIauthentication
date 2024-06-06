using APIauthentication.Helper;
using AuthenticationAPI.Models;

using Microsoft.AspNetCore.Mvc;


namespace AuthenticationAPI.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLogin userLogin)
        {
            var user = UserRepository.ValidateUser(userLogin.Username, userLogin.Password);

            if (user == null)
                return Unauthorized();

            var token = JwtHelper.GenerateToken(user.Username, user.Role);
            return Ok(new { token });
        }
        public class UserLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
