namespace PlanA.Models;

public class Sub_Process
{
    public required Guid ProcessId { get; set; }
    public required Process Process { get; set; }
    public required Guid SubProcessId { get; set; }
    public required Process SubProcess { get; set; }
}