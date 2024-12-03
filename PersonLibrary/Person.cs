namespace People;

// This class uses the current nullable settings in HIA2.

// TODO: Uncomment out this line to enable nullable reference types.
//#nullable enable

// After enabling nullable reference types, you can use nullable annotations to
// indicate whether a property or field can be null.  This is useful for
// highlighting a developer's intent on whether to allow null values in a
// property or field for development.

// Enabling nullables will not change the behavior of the code, but it will
// provide warnings for potential null reference exceptions, helping you to
// catch potential issues before they become runtime errors.

// You should be able to remove all the warnings using nullable annotations or
// null checks to change the states of the variables from "maybe-null" to
// "not-null" without changing any functionality.
public class Person
{
	/// <summary>
	/// The first name of the person.  Should never be <see langword="null"/>.
	/// </summary>
	public string FirstName { get; set; } = default;

	/// <summary>
	/// The surname of the person.  May be <see langword="null"/> if surname is unknown.
	/// </summary>
	public string LastName { get; set; } = default;

	/// <summary>
	/// The age of the person.  Will be <see langword="null"/> when unknown.
	/// </summary>
	public uint? Age { get; set; }

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Person()
	{
		FirstName = default;
		LastName = default;
	}

	public Person(string firstName, string lastName = null, uint? age = null)
	{
		FirstName = firstName;
		LastName = lastName;
		Age = age;
	}

	public string GetGreeting()
	// TODO: Add or remove nullable annotation.
	{
		// Returns null if the name is null.
		return FirstName != null ? $"Hello, {FirstName}!" : null;

		// This becomes a problem when nullables become enabled because a return
		// type of "string" tells the compiler you never intended to return a null
		// reference.

		// To fix this, you can change the return type to "string?" to tell consumers
		// to expect a null value / allow the compiler to check for "maybe-null" status.

		// Meanwhile, this code is fine because the FirstName property is not nullable.
		//return $"Hello, {FirstName}!";
	}
}
