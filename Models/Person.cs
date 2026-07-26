using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Person {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string LastName { get; set; }
	public string Patronymic { get; set; }
	public string PhoneNumber { get; set; }
	public DateTime Birthday { get; set; }
	public string Address { get; set; }
	
	public List<Employee> Employees { get; set; }
}