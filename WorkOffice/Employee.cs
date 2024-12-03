using System.Collections.Generic;
using People;

namespace Work;

// TODO: Uncomment the nullable context declaration.
//#nullable enable
public class Employee
{
	/// <summary>
	/// Underlying person object of the employee.
	/// </summary>
	private readonly Person _person;

	/// <summary>
	/// Person in the company is referred to by their surname.
	/// </summary>
	public string Name
	{
		get => _person.LastName;
		set => _person.LastName = value;
	}

	/// <summary>
	/// Job title of the employee.
	/// </summary>
	public string Title { get; }

	/// <summary>
	/// Whether the employee is a manager.
	/// </summary>
	public bool IsManager { get; }

	/// <summary>
	/// Employees managed by this employee. Will be <see langword="null"/> if the employee is not a manager.
	/// </summary>
	public IList<Employee> ManagedEmployees { get; }

	public Employee()
	{
		_person = new Person
		{
			FirstName = default,
			Age = default,
		};

		Title = default;
		IsManager = default;
	}

	public Employee(string name, uint age, string title, bool isManager)
	{
		_person = new Person
		{
			LastName = name,
			Age = age,
		};

		Title = title;
		IsManager = isManager;

		ManagedEmployees = isManager ? ([]) : null;
	}

	public string GetGreeting()
	{
		return $"Hello, {Name}, {Title}!";
	}
}
