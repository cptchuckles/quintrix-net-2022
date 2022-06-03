using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JwtApi.Attributes;

namespace JwtApi.Models
{
    public class UserDto
    {
        [Required]
        [MinLength(5)]
        public string Username { get; set; } = "";

        [Required]
        [MinLength(16)]
        [StrongPassword]
        public string Password { get; set; } = "";
    }
}