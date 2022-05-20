using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Program.Implementations;

namespace Program.Serialization
{
	public static class PlayerSerializer
	{
		public static void WriteList(List<Player> players, string filepath)
		{
			using (FileStream fs = new(filepath, FileMode.OpenOrCreate))
			{
				var options = new JsonSerializerOptions { WriteIndented = true };
				JsonSerializer.Serialize(fs, value: players, options: options);
			}
		}

		public static List<Player> ReadList(string filepath)
		{
			string jsonString = File.ReadAllText(filepath);
			return JsonSerializer.Deserialize<List<Player>>(jsonString);
		}
	}
}
