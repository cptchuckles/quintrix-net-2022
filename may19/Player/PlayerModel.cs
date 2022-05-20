using System;
using Program.Abstractions.Interfaces;

namespace Program.Abstractions.Models
{
	public abstract class PlayerModel : IPlayerModel
	{
		private Guid _id = Guid.NewGuid();
		public Guid Id => _id;
		
		public delegate void TaskToDo(PlayerModel whose);
		private TaskToDo _task;
		public TaskToDo Task { get => _task; set => _task = value; }

		public abstract string Name { get; set; }

		public abstract string Email { get; set; }

		public void DoTask()
		{
			if(_task == null)
			{
				Console.WriteLine($"{Name} has nothing to do");
				return;
			}
			_task(this);
		}
	}
}
