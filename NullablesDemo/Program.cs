using System;
using People;
using Work;

namespace NullablesDemo;

// TODO: Uncomment the nullable context declaration.
//#nullable enable
internal class Program
{
	private static void Main(string[] args)
	{
		if (args is not null)
			Console.WriteLine("Hello World!");

		// Interacting with potential null from legacy code
		// TODO: string?
		Person person1 = new("Alice", null, 30);
		Person person2 = new("Bob", "Boson");
		string greeting1 = person1.GetGreeting();
		string greeting2 = person2.GetGreeting();
		Console.WriteLine($"Greeting 1: {greeting1 ?? "null"}");
		Console.WriteLine($"Greeting 1: {greeting2 ?? "null"}");
		Console.WriteLine();

		// Legacy Address class interaction
		var address = new Address
		{
			// TODO: Set this to null to see warnings when nullables enabled.
			//Street = null,
			Street = "123 Main St",
			City = null // Generates warning when null in the modern app
						//City = "Blaine"
		};
		Console.WriteLine($"Address: {address.GetFullAddress()}");
		Console.WriteLine();

		// Handling nulls explicitly in the modern app
		Console.WriteLine("Processed Address:");
		Console.WriteLine(ProcessAddress(address));
		Console.WriteLine();


		// Work class stuff:
		var company = new Company();
		Console.WriteLine(company);
		Console.WriteLine();
	}

	private static string ProcessAddress(Address address)
	{
		string street = address.Street ?? "No Street Provided";
		// TODO: string?
		string streetNullable = address.Street;
		string city = address.City;
		return $"{street} ({streetNullable}), {city}";
	}
}
