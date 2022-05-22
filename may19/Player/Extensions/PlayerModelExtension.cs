using System;
using Program.Abstractions.Models;

namespace Program.Extensions
{
	public static class PlayerModelExtension
	{
		public static void SetPlayerInformation(this PlayerModel who, PlayerModel newPlayer)
		{
			who.Name = newPlayer.Name;
			who.Email = newPlayer.Email;
		}

		public static void PrintInformation(this PlayerModel who)
		{
			Console.WriteLine($"Player Information: {who.Name}");
			Console.WriteLine($"\tId: {who.Id}");
			Console.WriteLine($"\tEmail: {who.Email}");
			if (who.Task != null) Console.WriteLine($"\tHas Task: yes");
		}
	}
}
