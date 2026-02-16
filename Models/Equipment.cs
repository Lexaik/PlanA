namespace PlanA.Models;

public class Equipment {
	public int Id { get; set; }
	public required string Name { get; set; }
	public required double Cost { get; set; }
	public List<Employee> Employees { get; set; }
}