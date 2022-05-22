using System;

namespace Program.Abstractions.Interfaces
{
	public interface IPlayerModel
	{
		Guid Id { get; }
		string Name { get; set; }
		string Email { get; set; }
	}
}
