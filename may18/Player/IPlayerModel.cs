using System;

namespace PlayerProgram
{
	public interface IPlayerModel
	{
		Guid Id { get; }
		string Name { get; set; }
		string Email { get; set; }
	}
}
