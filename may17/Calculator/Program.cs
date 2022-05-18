Console.WriteLine("Calculator!");

while(true)
{
	try
	{
		Console.Write("Enter the first operand (int): ");

		int a;
		if (! Int32.TryParse(Console.ReadLine(), out a))
			throw new ApplicationException("Could not parse input");

		Console.Write("Enter an aritmetic operator: ");
		string? oper = Console.ReadLine();

		Console.Write("Enter the second operand: ");
		int b;
		if (! Int32.TryParse(Console.ReadLine(), out b))
			throw new ApplicationException("Could not parse input");

		int result = 0;
		switch (oper)
		{
		case "+": result = a+b; break;
		case "-": result = a-b; break;
		case "*": result = a*b; break;
		case "/": result = a/b; break;
		case "^":
			result = Convert.ToInt32(Math.Pow(a,b));
			break;
		default:
			throw new ApplicationException("YOU FOOL! GET OUT!!");
		}

		if (result == 42)
		{
			Console.WriteLine("You have just made an apple pie from scratch.");
		}
		else
		{
			Console.WriteLine($"{a} {oper} {b} = {result}");
		}
		break;
	}
	catch (Exception e)
	{
		Console.WriteLine($"User error: {e.Message}");
		Console.WriteLine("Try again");
	}
}

Console.WriteLine("Goodbye");
