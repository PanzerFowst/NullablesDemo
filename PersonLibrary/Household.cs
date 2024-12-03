using System.Collections.Generic;
using System.Text;

namespace People;

#nullable enable
public class Household
{
	public Address Address { get; } = new Address();

	public IList<Person?> PeopleLivingHere { get; } = [];

	public Household()
	{ }

	public Household(Address address, IList<Person?> people)
	{
		Address = address;
		PeopleLivingHere = people;
	}

	public static string GetNonNullablePeopleNames(IList<Person> people)
	{
		StringBuilder names = new();

		for (int i = 0; i < people.Count; i++)
		{
			Person person = people[i];

			// We trust that this is a not-null person, so no need to check for null references.
			_ = names.Append(GetPersonName(person));

			if (i < people.Count - 1)
			{
				_ = names.Append(", ");
			}
		}

		return names.ToString();
	}

	public static string GetNullablePeopleNames(IList<Person?> people)
	{
		StringBuilder names = new();

		for (int i = 0; i < people.Count; i++)
		{
			Person? person = people[i];

			// This is a maybe-null person, so the warning generated will tell you to
			// check for null references.
			if (person is not null)
			{
				_ = names.Append(GetPersonName(person));
			}

			if (i < people.Count - 1)
			{
				_ = names.Append(", ");
			}
		}

		return names.ToString();
	}

	private static string GetPersonName(Person person)
	{
		StringBuilder name = new();

		_ = name.Append(person.FirstName);

		if (person.LastName is not null)
		{
			// We already check for null references on the last name according to documentation.
			_ = name.Append(' ');
			_ = name.Append(person.LastName);
		}

		_ = name.Append($" (name length = {person.FirstName.Length + person.LastName?.Length})");

		return name.ToString();
	}
}
