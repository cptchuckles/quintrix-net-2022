using System;
using Program.Abstractions.Models;

namespace Program
{
	public static class PlayerModelTasks
	{
		public static void BuyGroceries(PlayerModel who)
		{
			Console.WriteLine($"{who.Name} is going to buy groceries");
		}

		public static void SellChickens(PlayerModel who)
		{
			Console.WriteLine($"{who.Name} is going to sell 27 chickens");
		}
	}
}
