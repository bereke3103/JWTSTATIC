using JWTWebToken.Models;
using JWTWebToken.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTWebToken.Service
{
    public class RegistrationService : IRegister
    {
        
        public static UserData user = new UserData();


        public IConfiguration Configuration;




        public RegistrationService(IConfiguration configuration)
        {
            Configuration = configuration;


        }


        public async Task<ActionResult<UserData>> Register(UserRequest request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;

            return user;
        }


        //public Task<ActionResult<UserData>> Login(UserRequest request)
        public async Task<string> Login(UserRequest request)
        {
            if (request.Username != user.Username)
            {
                return "User not found";
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return "Wrong password";
            }

            string token = CreateToken(user);
            return token;
        }



        public string CreateToken(UserData user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }




    }
}
