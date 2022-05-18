// See https://aka.ms/new-console-template for more information
Console.WriteLine("Debt Collector...!");

int debt = 10;
int paid = 0;

while(debt >= 0)
{
	Console.WriteLine($"Debt: ${debt--}  --- Paid: ${paid++}");
}

Console.WriteLine("I'M DEBT FREEEEEEE");
