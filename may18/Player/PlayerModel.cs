using System;
using System.Text.RegularExpressions;

namespace PlayerProgram
{
	public class PlayerModel : IPlayerModel
	{
		private static Regex _validEmailPattern = new Regex(
				@"^[a-zA-Z]\w*@(\w+\.)+\w+$",
				RegexOptions.Compiled
				);

		private Guid _id = Guid.NewGuid();
		public Guid Id => _id;
		
		public delegate void TaskToDo(PlayerModel whose);
		private TaskToDo? _task;
		public TaskToDo? Task { set => _task = value; }

		private string _name;
		public string Name
		{
			get => _name;
			set => _name = value;
		}

		private string _email;
		public string Email
		{
			get => _email;
			set => _email = ValidateEmail(value);
		}

		public PlayerModel(string name, string email)
		{
			Name = name;
			Email = email;
		}

		private static string ValidateEmail(string input)
		{
			if (! _validEmailPattern.IsMatch(input))
				throw new Exception("Invalid email given");

			return input;
		}

		public void DoTask()
		{
			if(_task == null)
			{
				Console.WriteLine($"{Name} has nothing to do");
				return;
			}
			_task(this);
		}
		
		public void PrintInformation()
		{
			Console.WriteLine($"Player Information:\n\tId: {Id}\n\tName: {Name}\n\tEmail: {Email}\n\tTask: {_task}");
		}
	}
}
