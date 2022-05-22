using System;

public class Factorial
{
	public static int Main(string[] args)
	{
		if (args.Length != 1)
		{
			Console.WriteLine($"Usage: factorial <number>");
			return 1;
		}

		ulong arg;
		if (! UInt64.TryParse(args[0], out arg))
		{
			Console.WriteLine("Could not parse integer argument");
			return 1;
		}

		ulong product = RecursiveFactorial(arg);
		Console.WriteLine($"{product}");

		return 0;
	}

	private static ulong RecursiveFactorial(ulong n)
	{
		if (n<=1)
		{
			Console.Write("1 = ");
			return n;
		}

		Console.Write($"{n} * ");
		return n * RecursiveFactorial(n - 1);
	}
}
