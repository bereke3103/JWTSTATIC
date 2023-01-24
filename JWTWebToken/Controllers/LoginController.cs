using JWTWebToken.Models;
using JWTWebToken.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public LoginController(IRegister register)
        {
            _register = register;

        }

        public IRegister _register;

        [HttpPost("login")]
        public async Task<ActionResult<UserData>> Login(UserRequest request)
        {


            var response = await _register.Login(request);

            return Ok(response);

        }
    }
}
