using System;


public class Weekdays
{
	enum Weekday {
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday
	}

	static void Main(string[] args)
	{
		Console.WriteLine("Days of the week");

		Weekday day = Weekday.Monday;

		while(true)
		{
			Console.WriteLine($"{day++}...");
			if (day > Weekday.Friday) break;
		}

		Console.WriteLine("WOOHOO!");
	}
}
