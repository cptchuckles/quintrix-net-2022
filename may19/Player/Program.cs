using System;
using System.Linq;
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
			players.Add(new Robot("Jim Grocerybuyer"));
			players.Add(new Robot("Leeroy Chickenseller"));
			players[0].Task = BuyGroceries;
			players[1].Task = SellChickens;

			Console.Clear();

			while(true)
			{
				try
				{
START:
					Console.Clear();
					Console.WriteLine($"There are now {players.Count} players.");
					{
						uint i=0;
						foreach (var player in players)
							Console.WriteLine($"{++i}. {player.Name}");
						Console.WriteLine($"{++i}. <Add New Player>");
						Console.WriteLine($"{++i}. <Save Players>");
						Console.WriteLine($"{++i}. <Load Players>");
					}
					PlayerModel? selectedPlayer;

					uint choice;
					GetInput<uint>("Enter selection: ", out choice);

					if (choice == players.Count+1)
					{
						players.Add(CreatePlayerInteractively());
						continue;
					}
					else if (choice == players.Count+2)
					{
						var noBots = from item in players
						             where item is Player
						             select (Player)item;

						PlayerSerializer.WriteList(new List<Player>(noBots), "Players.json");
						continue;
					}
					else if (choice == players.Count+3)
					{
						HashSet<Guid> guids = new(from player in players select player.Id);
						foreach (Player player in PlayerSerializer.ReadList("Players.json"))
						{
							if (guids.Contains(player.Id))
							{
								Player overwritePlayer = (Player)players.Find((p) => p.Id == player.Id);
								overwritePlayer.Name = player.Name;
								overwritePlayer.Email = player.Email;
							}
							else
							{
								players.Add(player);
							}
						}
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
								Console.Clear();
								goto START;
							default:
								throw new IndexOutOfRangeException();
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
					Console.WriteLine($"Error: {e}");
					Console.Read();
					Console.Clear();
				}
			}
		} // public static void Main()

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
