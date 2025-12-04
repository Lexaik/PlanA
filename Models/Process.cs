namespace PlanA.Models;

public class Process
{
    public int ProcessId { get; set; }
    public required string Name { get; set; }
    public List<Operation> Operations { get; set; } = new();
    public List<Process> SubProcesses { get; set; } = new();
    public required TimeSpan Duration { get; set; }
    public required int Quantity { get; set; }
    public List<Sub_process> ItemSubProcesses { get; set; } = new();
}
