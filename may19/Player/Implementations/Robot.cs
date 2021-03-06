using System;
using Program.Abstractions.Models;

namespace Program.Implementations
{
	public sealed class Robot : PlayerModel
	{
		private string _name;
		public override string Name
		{
			get => _name;
			set { throw new Exception("Cannot modify Robot.Name"); }
		}

		private string _email;
		public override string Email
		{
			get => _email;
			set { throw new Exception("Cannot modify Robot.Email"); }
		}

		public Robot(string name)
		{
			string digits = Id.ToString().Split('-')[0];
			_name = $"{name.Replace(' ', '-')}-{digits}";
			_email = $"{name.Split(' ')[0]}{digits}@sharklazers.com";
		}
	}
}
