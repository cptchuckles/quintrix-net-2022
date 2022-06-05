using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JwtApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NoWhitespaceAttribute : ValidationAttribute
    {
        public new string ErrorMessage = "Username cannot contain whitespace.";
        public override string FormatErrorMessage(string name) => ErrorMessage;

        public override bool IsValid(object? value)
        {
            return ! Regex.IsMatch((string)value!, @"\s");
        }
    }
}