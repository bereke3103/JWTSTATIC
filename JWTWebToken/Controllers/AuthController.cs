using JWTWebToken.Models;
using JWTWebToken.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegister register;
     

        //public static UserData userData = new UserData();

        //public IConfiguration Configuration;

        public AuthController(IRegister register)
        {
            this.register = register;
         
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserData>> Register(UserRequest request)
        {
            var userData = await register.Register(request);

            return Ok(userData);
        }


       
    }
}
