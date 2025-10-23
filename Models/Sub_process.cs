namespace PlanA.Models;

public class Sub_process
{
    public required int ProcessId { get; set; }
    public Process Process { get; set; }
    public required int SubProcessId { get; set; }
    public Process? SubProcess { get; set; }
}