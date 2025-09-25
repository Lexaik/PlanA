namespace PlanA.Models;

public class Operation
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public TimeSpan Duration { get; set; }
}