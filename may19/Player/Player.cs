using System;
using System.Text.RegularExpressions;
using Program.Abstractions.Models;

namespace Program.Implementations
{
	public class Player : PlayerModel
	{
		private static Regex _validEmailPattern = new Regex(
				@"^[a-zA-Z]\w*@(\w+\.)+\w+$",
				RegexOptions.Compiled
				);

		public Player(string name, string email)
		{
			Name = name;
			Email = email;
		}

		private string _name;
		public override string Name { get => _name; set => _name = value; }

		private string _email;
		public override string Email
		{
			get => _email;
			set => _email = ValidateEmail(value);
		}

		private static string ValidateEmail(string input)
		{
			if (! _validEmailPattern.IsMatch(input))
				throw new Exception("Invalid email given");

			return input;
		}
	}
}
