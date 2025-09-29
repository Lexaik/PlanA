namespace PlanA.Models;

public class Operation
{
    public int OperationId { get; init; }
    public required string Name { get; set; }
    public required TimeSpan Duration { get; set; }
    public List<Item> OperationSources { get; set; } = new();
    public List<Item> OperationSupplies { get; set; } = new();
    public List<Item> OperationResults { get; set; } = new();
    public List<Item> OperationRemains { get; set; } = new();
}