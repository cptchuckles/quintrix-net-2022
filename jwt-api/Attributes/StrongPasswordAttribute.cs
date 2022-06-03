using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JwtApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StrongPasswordAttribute : ValidationAttribute
    {
        public new string ErrorMessage = "The password must contain at least all of the following criteria: 10 alphabetic characters of mixed case, 5 numeric characters, and 1 non-alphanumeric character.";
        public override string FormatErrorMessage(string name) => ErrorMessage;
        public override bool IsValid(object? value)
        {
            string? input = value as string;
            if (input is null) return false;

            if (Regex.Matches(input, @"[a-zA-Z]").Count < 10) return false;
            if (Regex.Matches(input, @"[A-Z]").Count < 1) return false;
            if (Regex.Matches(input, @"[a-z]").Count < 1) return false;
            if (Regex.Matches(input, @"[0-9]").Count < 5) return false;
            if (Regex.Matches(input, @"[^a-zA-Z0-9]").Count < 1) return false;

            return true;
        }
    }
}