namespace PlanA.Models;

public class Employee {
	public int Id { get; set; }
	public required string Profession { get; set; }
	public required double Salary { get; set; }
    
	public Person? Person { get; set; }
	public List<Equipment>? Equipments { get; set; }
}