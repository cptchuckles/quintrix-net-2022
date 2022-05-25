using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace QuintrixMVC.Models
{
    public class Player : IdentityUser
    {
        private static Regex _validEmailPattern = new Regex(
                @"^[a-zA-Z]\w*@(\w+\.)+\w+$",
                RegexOptions.Compiled
                );

        public Guid Id { get; set; }

        private string _name;
        public string Name { get => _name; set => _name = value; }

        private string _email;
        public string Email
        {
            get => _email;
            set => _email = ValidateEmail(value);
        }

        public uint BodyCount { get; set; }

        public Player() {}

        private static string ValidateEmail(string input)
        {
            if (! _validEmailPattern.IsMatch(input))
                throw new Exception("Invalid email given");

            return input;
        }
    }
}
