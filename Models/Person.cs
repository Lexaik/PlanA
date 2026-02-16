namespace PlanA.Models;

public class Person {
	public int Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public string Patronymic { get; set; }
	public string PhoneNumber { get; set; }
	public DateTime Birthday { get; set; }
	public string Address { get; set; }
	
	public List<Employee> Employees { get; set; }
}