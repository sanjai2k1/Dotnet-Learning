using jwttest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwttest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly jwtService _jwtService;
        
        
        
        public AuthController(jwtService jwtService)
        {
            _jwtService = jwtService;
            
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetToken()
        {
            string token = _jwtService.GenerateJSONWebToken();

            var cookieoptions =
                 new CookieOptions()
                 {
                   
                     Expires = DateTime.Now.AddHours(3)
                 };
            Response.Cookies.Append("jwtcookie", token, cookieoptions);

            return Ok(new
            {
                token
            });

        }
    }
}
