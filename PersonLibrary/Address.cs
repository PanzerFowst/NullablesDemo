namespace People;

// Represents a class that already implements nullables.

#nullable enable
public class Address
{
	public string? Street { get; set; } = default;

	public string City { get; set; }

	public Address()
	{
		// THIS IS DANGEROUS!  You are lying to the compiler by saying that Street
		// will never be null while setting it to null via the null-forgiving
		// operator (!).
		City = default!;

		// This is a better way to set the City property to a default value.
		City = string.Empty;
		// Or even:
		City = "Eden Prairie";
	}

	public Address(string? city)
	{
		// Just setting a "string?" to a "string" is problematic because of the
		// "maybe-null" state of city, generating a warning.
		//City = city;

		if (city is not null)
		{
			// Here, the city variable is now "not-null" because you checked for
			// null references.
			City = city;
		}
		else
		{
			// Without this fallback value, city would be assigned null by the end
			// of the constructor, generating a warning.
			City = string.Empty;
		}
	}

	public Address(string? street, string city)
	{
		Street = street;
		City = city;
	}

	public string GetFullAddress()
	{
		return $"{Street}, {City}";
	}

	public int GetFullAddressLength()
	{
		int length = 0;

		// This is a maybe-null Street, so the warning generated will tell you to
		// check for null references, but will act the same as if you had not
		// enabled nullable reference types, throwing a NullReferenceException when
		// null.
		//length += Street.Length;

		// This if check will change the status of Street from "maybe-null" to
		// "not-null" because you are checking for null references.
		//if (Street is not null) {
		//	length += Street.Length;
		//}

		// And yet another way you can check is by using the null-conditional operator.
		length += Street?.Length ?? 0;

		length += 2; // ", ".Length
		length += City.Length;

		return length;
	}
}
