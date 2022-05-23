using System;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using Program.Abstractions.Models;

namespace Program.Implementations
{
	public class Player : PlayerModel
	{
		private static Regex _validEmailPattern = new Regex(
				@"^[a-zA-Z]\w*@(\w+\.)+\w+$",
				RegexOptions.Compiled
				);

		private string _name;
		public override string Name { get => _name; set => _name = value; }

		private string _email;
		public override string Email
		{
			get => _email;
			set => _email = ValidateEmail(value);
		}

		public Player(string name, string email)
		{
			Name = name;
			Email = email;
		}

		[JsonConstructor]
		public Player(string name, string email, Guid id)
		{
			Name = name;
			Email = email;
			_id = id;
		}

		public static Player CreateInteractively()
		{
			Console.Write("Enter name: ");
			string playerName = Console.ReadLine();
			if (playerName == "") throw new Exception("No name entered");

			Console.Write("Enter email: ");
			string emailAddress = Console.ReadLine();
			if (emailAddress == "") throw new Exception("No email entered");

			return new Player(playerName, emailAddress);
		}

		private static string ValidateEmail(string input)
		{
			if (! _validEmailPattern.IsMatch(input))
				throw new Exception("Invalid email given");

			return input;
		}
	}
}
