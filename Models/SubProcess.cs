namespace PlanA.Models;

public class Sub_Process
{
    public required int ProcessId { get; set; }
    public required Process Process { get; set; }
    public required int SubProcessId { get; set; }
    public required Process SubProcess { get; set; }
}