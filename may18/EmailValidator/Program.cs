using System;
using System.Text.RegularExpressions;
using System.Net.Mail;

public class EmailValidator
{
	public static void Main(string[] args)
	{
		// Shamelessly stolen from Daniel, but it's okay because he stole it from somewhere else:
		string regex = @"^([\w.-]+)@([\w-]+)((.(\w){2,})+)$";

		while(true)
		{
			Console.Write("Enter an email address: ");

			string? input = Console.ReadLine();
			bool regexMatch = false;

			regexMatch = Regex.IsMatch(input, regex);

			MailAddress? address;

			if (! MailAddress.TryCreate(input, result: out address))
			{
				Console.WriteLine($"{input} is not a valid email address");
				if (regexMatch)
				{
					Console.WriteLine("But the regex check passed, so it must be garbage");
				}
			}
			else {
				Console.WriteLine("Finally, I can die");
				return;
			}

			Console.WriteLine("No dice, try again");
		}
	}
}
