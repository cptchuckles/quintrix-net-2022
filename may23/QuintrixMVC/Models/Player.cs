using System;
using System.Text.RegularExpressions;

using System.ComponentModel.DataAnnotations;

namespace QuintrixMVC.Models
{
    public class Player
    {
        private static Regex _validEmailPattern = new Regex(
                @"^[a-zA-Z]\w*@(\w+\.)+\w+$",
                RegexOptions.Compiled
                );

        [Key]
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
