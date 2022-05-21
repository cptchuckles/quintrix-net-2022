using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Program.Abstractions.Models;
using Program.Implementations;
using Program.Serialization;
using Program.Exceptions;
using static Program.Extensions.PlayerModelExtension;

namespace Program
{
	public class Program
	{
		private static List<PlayerModel> players = new();

		public static void Main(string[] args)
		{
			Console.Clear();
			players.Add(new Robot("Jim Grocerybuyer"));
			players.Add(new Robot("Leeroy Chickenseller"));
			players[0].Task = BuyGroceries;
			players[1].Task = SellChickens;

			while(true)
			{
				Console.Clear();
				Console.WriteLine($"There are now {players.Count} players.");

				DisplayMainMenu();

				PlayerModel selectedPlayer;

				try
				{
					char choice;
					GetInput<char>("Enter selection: ", out choice);

					switch (choice)
					{
					case 'n':
						players.Add(CreatePlayerInteractively());
						break;
					case 'w':
						WritePlayerListToFile("Players.json");
						break;
					case 'r':
						LoadPlayerListFromFile("Players.json");
						break;
					default:
						selectedPlayer = players[(int)(choice - '0') - 1];
						while(PlayerOptionsSubmenu(selectedPlayer));
						break;
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
					Console.WriteLine($"Error: {e}");
					Console.Read();
				}
			}
		} // public static void Main()

		private static void GetInput<T>(string prompt, out T output)
		{
			Console.Write(prompt);

			string? input = Console.ReadLine();
			if (input == null || input.Length == 0)
				throw new NoInputException("No input given by user");

			output = (T)Convert.ChangeType(input, typeof(T));
		}

		private static void DisplayMainMenu()
		{
			Console.WriteLine("----------------------");
			uint i=0;
			foreach (var player in players)
				Console.WriteLine($"{++i}. {player.Name}");
			Console.WriteLine("----------------------");
			Console.WriteLine("<n>. New Player");
			Console.WriteLine("<w>. Write Player List to disk");
			Console.WriteLine("<r>. Read Player List from disk");
			Console.WriteLine("< >. Quit");
			Console.WriteLine("----------------------");
		}

		private static void WritePlayerListToFile(string filepath)
		{
			var noBots = players
				.Where(p => p is Player)
				.Select(p => (Player)p)
				.ToList();

			PlayerSerializer.WriteList(noBots, filepath);
		}

		private static void LoadPlayerListFromFile(string filepath)
		{
			Hashtable playerById = new(
				players
				.Where(p => p is Player)
				.ToDictionary(p => p.Id, p => (Player)p)
			);

			foreach (Player p in PlayerSerializer.ReadList(filepath))
			{
				if (playerById.Contains(p.Id))
				{
					Player overwritePlayer = (Player)playerById[p.Id];
					overwritePlayer.Name = p.Name;
					overwritePlayer.Email = p.Email;
				}
				else
				{
					players.Add(p);
				}
			}
		}

		private static bool PlayerOptionsSubmenu(PlayerModel selectedPlayer)
		{
			Console.Clear();
			Console.WriteLine($"{selectedPlayer.Name} selected.");
			Console.WriteLine("----------------------");
			Console.WriteLine("1. Display information");
			Console.WriteLine("2. Change name and email");
			Console.WriteLine("3. Perform task");
			Console.WriteLine("4. Return to player list");
			Console.WriteLine("----------------------");

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
				if (selectedPlayer is Robot)
					throw new Exception($"{selectedPlayer.Name} is a robot and cannot be changed.");
				selectedPlayer.SetPlayerInformation(CreatePlayerInteractively());
				break;
			case 3:
				selectedPlayer.DoTask();
				Console.WriteLine("Press any key to continue");
				Console.ReadLine();
				break;
			case 4:
				return false;
			default:
				throw new IndexOutOfRangeException();
			}

			return true;
		}

		private static Player CreatePlayerInteractively()
		{
			string playerName;
			GetInput<string>("Enter name: ", out playerName);
			string emailAddress;
			GetInput<string>("Enter email: ", out emailAddress);
			return new Player(playerName, emailAddress);
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
