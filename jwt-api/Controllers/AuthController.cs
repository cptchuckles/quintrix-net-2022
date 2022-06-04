using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using JwtApi.Models;
using JwtApi.Data;

namespace JwtApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public ActionResult<string> Register([FromBody] RegisterUserDto request)
        {
            using (var context = new ApplicationDbContext())
            {
                if (context.Users!.Any(u => u.Username == request.Username))
                    return BadRequest($"Username {request.Username} already exists");

                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                context.Add<User>(new User(request.Username, passwordHash, passwordSalt));
                context.SaveChanges();
            }

            var createdResult = new ObjectResult($"User created: {request.Username}");
            createdResult.StatusCode = 201;
            return createdResult;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] LoginUserDto request)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users!.FirstOrDefault(
                    u => u.Username.ToLower() == request.Username.ToLower());

                if (user is null)
                    return BadRequest("Username or password incorrect");
                
                if (! VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    return BadRequest("Username or password incorrect");

                var token = CreateToken(user);
                return Ok(token);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration.GetSection("Jwt:Key").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}