using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtApi.Data;
using JwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("Public")]
        public ActionResult<string> Public()
        {
            return Ok("You are on government property.  Prepare to be anally probed.");
        }

        [Authorize]
        [HttpGet("Whoami")]
        public IActionResult WhoAmI()
        {
            var currentUser = GetCurrentUser();

            return Ok($"You are {currentUser.Username} and your role is {currentUser.Role}");
        }

        [Authorize(Roles = "Admin,Gigachad")]
        [HttpGet("List")]
        public IActionResult List()
        {
            using (var context = new ApplicationDbContext())
            {
                return Ok(string.Join("\n", context.Users!.Select(u => $"{u.Username}\t{u.Role}").ToList()));
            }
        }

        [Authorize(Roles = "Gigachad")]
        [HttpPut("Enroll")]
        public IActionResult Enroll(string username, string role)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users!.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
                if (user is null) return NotFound($"User {username} was not found");

                user.Role = role;
                context.Update(user);
                context.SaveChanges();
                return Ok($"Enrolled {user.Username} in role {role}");
            }
        }

        [Authorize(Roles = "Gigachad,Admin")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Guid userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users!.FirstOrDefault(u => u.Id == userId);
                if (user is null) return NotFound($"User Id {userId} not found");
                context.Remove(user);
                context.SaveChanges();
                return Ok($"User {user.Username} deleted");
            }
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is not null)
            {
                var claims = identity.Claims;
                return new User() {
                    Username = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value!,
                    Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value!
                };
            }

            return null!;
        }
    }
}