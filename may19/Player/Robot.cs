using System;
using Program.Abstractions.Models;

namespace Program.Implementations
{
	public sealed class Robot : PlayerModel
	{
		public Robot(string name)
		{
			string digits = Id.ToString().Split('-')[0];
			_name = $"{name.Replace(' ', '-')}-{digits}";
			_email = $"{name.Split(' ')[0]}{digits}@sharklazers.com";
		}

		private string _name;
		public override string Name { get => _name; set {} }

		private string _email;
		public override string Email { get => _email; set {} }
	}
}
