namespace PlanA.Models;

public class Process
{
    public int ProcessId { get; set; }
    public int OperationId { get; set; }
    public int Quantity { get; set; }
    public TimeSpan Duration { get; set; }
}
