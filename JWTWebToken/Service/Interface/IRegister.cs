using JWTWebToken.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebToken.Service.Interface
{
    public interface IRegister
    {
        public Task<ActionResult<UserData>> Register(UserRequest request);

        public Task<string> Login(UserRequest request);

        public string CreateToken(UserData user);


    }
}
