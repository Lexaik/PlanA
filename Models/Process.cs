namespace PlanA.Models;

public class Process
{
    public int ProcessId { get; set; }
    public List<Operation> Operations { get; set; } = new();
    public List<Process> SubProcesses { get; set; } = new();
    public required TimeSpan Duration { get; set; }
}
