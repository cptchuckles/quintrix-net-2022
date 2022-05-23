using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Program.Abstractions.Models;
using Program.Implementations;
using Program.Serialization;
using static Program.Extensions.PlayerModelExtension;

namespace Program
{
	public class Program
	{
		private List<PlayerModel> _players = new();

		public Program()
		{
			_players.Add(new Robot("Jim Grocerybuyer"));
			_players.Add(new Robot("Leeroy Chickenseller"));
			_players[0].Task = PlayerModelTasks.BuyGroceries;
			_players[1].Task = PlayerModelTasks.SellChickens;
		}

		public static void Main(string[] args)
		{
			var program = new Program();

			program.MainLoop();
		}

		public void MainLoop()
		{
			while (true)
			{
				try
				{
					if (! MainMenu()) return;
				}
				catch (Exception e)
				{
					Console.Clear();
					Console.WriteLine($"Error: {e}");
					Console.Read();
				}
			}
		}

		private bool MainMenu()
		{
			Console.Clear();

			Console.WriteLine("----------- Players -----------");
			uint i=0;
			foreach (var player in _players)
				Console.WriteLine($"{++i}. {player.Name}");
			Console.WriteLine("----------- Actions -----------");
			Console.WriteLine("<n>. New Player");
			Console.WriteLine("<w>. Write Player List to disk");
			Console.WriteLine("<r>. Read Player List from disk");
			Console.WriteLine("<q>. Quit");
			Console.WriteLine("-------------------------------");

			Console.Write("Select player or action: ");
			string choice = Console.ReadLine();

			switch (choice)
			{
			case "n":
				_players.Add(Player.CreateInteractively());
				break;
			case "w":
				WritePlayerListToFile("Players.json");
				break;
			case "r":
				ReadPlayerListFromFile("Players.json");
				break;
			case "q":
				Console.WriteLine("Goodbye");
				return false;
			default:
				var selectedPlayer = _players[Int32.Parse(choice) - 1];
				while (PlayerOptionsSubmenu(selectedPlayer));
				break;
			}

			return true;
		}

		private void WritePlayerListToFile(string filepath)
		{
			var noBots = _players
				.Where(p => p is Player)
				.Select(p => (Player)p)
				.ToList();

			PlayerSerializer.WriteList(noBots, filepath);
		}

		private void ReadPlayerListFromFile(string filepath)
		{
			Hashtable playerById = new(
				_players
				.Where(p => p is Player)
				.ToDictionary(p => p.Id, p => (Player)p)
			);

			foreach (Player p in PlayerSerializer.ReadList(filepath))
			{
				if (playerById.Contains(p.Id))
				{
					var overwritePlayer = (Player)playerById[p.Id];
					overwritePlayer.Name = p.Name;
					overwritePlayer.Email = p.Email;
				}
				else
				{
					_players.Add(p);
				}
			}
		}

		private bool PlayerOptionsSubmenu(PlayerModel selectedPlayer)
		{
			Console.Clear();

			Console.WriteLine($"{selectedPlayer.Name} selected.");
			Console.WriteLine("----------------------");
			Console.WriteLine("1. Display information");
			Console.WriteLine("2. Change name and email");
			Console.WriteLine("3. Perform task");
			Console.WriteLine("4. Return to player list");
			Console.WriteLine("----------------------");

			Console.Write("Select an action: ");
			int action = Int32.Parse(Console.ReadLine());

			switch (action)
			{
			case 1:
				selectedPlayer.PrintInformation();
				Console.WriteLine("Press any key to continue");
				Console.Read();
				break;
			case 2:
				if (selectedPlayer is Robot)
					throw new Exception($"{selectedPlayer.Name} is a robot and cannot be changed.");
				selectedPlayer.SetPlayerInformation(Player.CreateInteractively());
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
	}
}
