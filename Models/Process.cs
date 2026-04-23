namespace PlanA.Models;

public class Process {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required TimeSpan Duration { get; set; }
    public required int Quantity { get; set; }
    
    public List<Operation> Operations { get; set; } = new();
    public List<Sub_Process>? SubProcesses { get; set; } = new();
}
