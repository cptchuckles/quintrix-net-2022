using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
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
            if (currentUser is null) return new StatusCodeResult(500);

            var response = new Dictionary<string,string>() {
                ["Id"] = currentUser.Id.ToString(),
                ["Username"] = currentUser.Username,
                ["Role"] = currentUser.Role
            };

            Response.ContentType = "application/json";
            return Ok(JsonSerializer.Serialize(response));
        }

        [Authorize(Roles = "Admin,Gigachad")]
        [HttpGet("List")]
        public IActionResult List()
        {
            using (var context = new ApplicationDbContext())
            {
                var list =
                    context.Users?
                    .AsEnumerable()
                    .Select(u => new Dictionary<string,string>() {
                        ["Id"]=u.Id.ToString(),
                        ["Username"]=u.Username,
                        ["Role"]=u.Role })
                    .ToList();
                
                Response.ContentType = "application/json";
                return Ok(JsonSerializer.Serialize(list));
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

        private User? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is not null)
            {
                var claims = identity.Claims;
                var username = claims.FirstOrDefault(e => e.Type == ClaimTypes.Name)?.Value;
                using (var context = new ApplicationDbContext())
                {
                    return context.Users?.FirstOrDefault(u => u.Username == username);
                }
            }

            return null!;
        }
    }
}