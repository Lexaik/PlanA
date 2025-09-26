namespace PlanA.Models;

public class Item
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public List<Operation> Operations { get; set;} = new();
}