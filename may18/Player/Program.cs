using System;
using System.Collections.Generic;

namespace PlayerProgram
{
	public class NoInputException : Exception
	{
		public NoInputException(string message) {}
	}

	public class Program
	{
		private static List<PlayerModel> players = new List<PlayerModel>();

		private static void GetInput<T>(string prompt, out T output)
		{
			Console.Write(prompt);

			string? input = Console.ReadLine();
			if (input == null || input.Length == 0)
				throw new NoInputException("No input given by user");

			output = (T)Convert.ChangeType(input, typeof(T));
		}

		public static void Main(string[] args)
		{
			Console.Clear();
			players.Add(new PlayerModel("Jim Grocerybuyer", "jim@groceries.com"));
			players.Add(new PlayerModel("Leeroy Chickenseller", "leeroy@lol.wtf"));
			players[0].Task = BuyGroceries;
			players[1].Task = SellChickens;

			Console.Clear();

			while(true)
			{
				try
				{
START:
					Console.WriteLine($"There are now {players.Count} players.");
					{
						uint i=0;
						foreach (var player in players)
							Console.WriteLine($"{++i}. {player.Name}");
						Console.WriteLine($"{++i}. <Add New Player>");
					}
					PlayerModel? selectedPlayer;


					uint choice;
					GetInput<uint>("Enter selection: ", out choice);

					if (choice == players.Count+1)
					{
						players.Add(CreatePlayerInteractively());
						continue;
					}

					selectedPlayer = players[(int)choice - 1];

					while(true)
					{
						Console.Clear();
						Console.WriteLine($"{selectedPlayer.Name} selected.");
						Console.WriteLine("1. Display information");
						Console.WriteLine("2. Change name and email");
						Console.WriteLine("3. Perform task");
						Console.WriteLine("4. Return to player list");

						uint action;
						GetInput<uint>("Select an action (number): ", out action);

						switch(action)
						{
							case 1:
								selectedPlayer.PrintInformation();
								Console.WriteLine("Press any key to continue");
								Console.Read();
								break;
							case 2:
								SetPlayerInformation(selectedPlayer);
								break;
							case 3:
								selectedPlayer.DoTask();
								Console.WriteLine("Press any key to continue");
								Console.ReadLine();
								break;
							default:
								Console.Clear();
								goto START;
						}
					}
				}
				catch(NoInputException e)
				{
					Console.WriteLine("Goodbye");
					return;
				}
				catch(Exception e)
				{
					Console.Clear();
					Console.WriteLine($"Error: {e.Message}");
					Console.Read();
					Console.Clear();
				}
			}
		} // public static void Main()

		private static PlayerModel CreatePlayerInteractively()
		{
			string playerName;
			GetInput<string>("Enter name: ", out playerName);
			string emailAddress;
			GetInput<string>("Enter email: ", out emailAddress);
			return new PlayerModel(playerName, emailAddress);
		}

		private static void SetPlayerInformation(PlayerModel who)
		{
			var newPlayer = CreatePlayerInteractively();
			who.Name = newPlayer.Name;
			who.Email = newPlayer.Email;
		}
		
		private static void BuyGroceries(PlayerModel who)
		{
			Console.WriteLine($"{who.Name} is going to buy groceries");
		}
		
		private static void SellChickens(PlayerModel who)
		{
			Console.WriteLine($"{who.Name} is going to sell 27 chickens");
		}
	}
}
