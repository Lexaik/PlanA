using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Employee {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
	public required string Profession { get; set; }
	public required double Salary { get; set; }
    
	public Person? Person { get; set; }
	public List<Equipment>? Equipments { get; set; }
}