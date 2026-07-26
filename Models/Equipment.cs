using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Equipment{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required double Cost { get; set; }
	public List<Employee> Employees { get; set; }
}