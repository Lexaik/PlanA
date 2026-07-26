using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Operation {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required TimeSpan Duration { get; set; }
    
    public List<Item> Items { get; set; } = new();
    public List<OperationItems> OperationItems { get; set;} = new();
    public List<Process> Processes { get; set; } = new();
}