using System.Collections.Generic;
using System.Text;

namespace Work;

public class Company
{
	public IList<Employee> Employees { get; }

	public Company()
	{
		var allisson = new Employee("Allisson", 30, "CEO", true);
		var boson = new Employee("Boson", 25, "Manager", true);
		var charleston = new Employee("Charleston", 22, "Developer", false);
		var davidson = new Employee("Davidson", 35, "Developer", false);
		var everson = new Employee("Everson", 28, "Developer", false);
		var frankston = new Employee("Frankston", 40, "Developer", false);

		// Assigning managed employees to managers.
		allisson.ManagedEmployees.Add(boson);
		allisson.ManagedEmployees.Add(charleston);
		boson.ManagedEmployees.Add(davidson);
		boson.ManagedEmployees.Add(everson);
		boson.ManagedEmployees.Add(frankston);

		// TODO: This should throw an exception because Charleston is not a manager.
		//charleston.ManagedEmployees.Add(davidson);
		// However, we can't tell to check for a null value via compiler warnings. Hence the beauty of nullables.

		Employees =
		[
			allisson,
			boson,
			charleston,
			davidson,
			everson,
			frankston
		];
	}

	public override string ToString()
	{
		StringBuilder sb = new();

		foreach (Employee employee in Employees)
		{
			_ = sb.Append(employee.Name);
			_ = sb.Append(" (");
			_ = sb.Append(employee.Title);
			_ = sb.Append(')');
			_ = sb.Append(" manages: ");

			if (employee.ManagedEmployees is not null && employee.ManagedEmployees.Count > 0)
			{
				_ = sb.Append(employee.ManagedEmployees[0].Name);

				for (int i = 1; i < employee.ManagedEmployees.Count; i++)
				{
					_ = sb.Append(", ");
					_ = sb.Append(employee.ManagedEmployees[i].Name);
				}
			}
			else
			{
				_ = sb.Append("none");
			}

			_ = sb.AppendLine();
		}

		return sb.ToString();
	}
}
