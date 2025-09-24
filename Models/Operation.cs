namespace PlanA.Models;

public class Operation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public Dictionary<Product, int> Components { get; set; } = new();
    public Dictionary<Product, int> Supplyes { get; set; } = new();
    public Dictionary<Product, int> Remains { get; set; } = new();
    public Dictionary<Product, int> Results { get; set; } = new();
}