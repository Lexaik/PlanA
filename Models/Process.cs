using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace PlanA.Models;

public class Process {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required Period Duration { get; set; }
    public required int Quantity { get; set; }
    
    public List<Operation> Operations { get; set; } = new();
    public List<Sub_Process>? SubProcesses { get; set; } = new();
}
