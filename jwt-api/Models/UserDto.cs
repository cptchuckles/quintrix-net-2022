using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.Attributes;

namespace JwtApi.Models
{
    internal interface IUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserDto : IUserDto
    {
        [Required]
        [MinLength(5)]
        [NoWhitespace]
        public string Username { get; set; } = "";

        [Required]
        [MinLength(16)]
        [StrongPassword]
        public string Password { get; set; } = "";
    }

    public class LoginUserDto : IUserDto
    {
        [Required]
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}