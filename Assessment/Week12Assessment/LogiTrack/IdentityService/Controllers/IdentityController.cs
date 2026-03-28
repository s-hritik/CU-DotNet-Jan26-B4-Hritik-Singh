using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityService.Models;
using System.Diagnostics.Contracts;
using IdentityService.DTOs;
using IdentityService.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public IdentityController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        private static List<Login> _loginList = new List<Login>()
        {
            new Login
            {
                Id = "1",
                Email = "driver@gmail.com",
                Role = "Driver",
                PasswordHash = "Password"
            },
            new Login
            {
                Id = "2",
                Email = "manager@gmail.com",
                Role = "Manager",
                PasswordHash = "Password"
            }
        };

        [HttpPost("register")]

        public IActionResult Register(RegisterDTO dto)
        {
            _loginList.Add( new Login
            {
                Id = _loginList.Count().ToString(),
                Email = dto.Email,
                Role = dto.Role,
                PasswordHash = dto.Password
            });

            return Ok("Successfully Registered");
        }

        [HttpPost("login")]

        public IActionResult Login(LoginDTO dto)
        {
            var login = _loginList.FirstOrDefault(x => x.Email == dto.Email);
            if (login == null) return BadRequest("Email Not Found");

            else if (login.PasswordHash != dto.Password) return BadRequest("Invalid Password");

                var token = _tokenService.CreateToken(login, new List<string> { login.Role });
                return Ok(new { token });            
        }
    }
}
