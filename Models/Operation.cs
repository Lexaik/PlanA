using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Operation
{
    public int OperationId { get; init; }
    public required string Name { get; set; }
    public required TimeSpan Duration { get; set; }
    
    public List<Item> Items { get; set; } = new();
    public List<Operation_items> OperationItems { get; set;} = new();
}