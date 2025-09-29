namespace PlanA.Models;

public class Item
{
    public int ItemId { get; init;}
    public required string Name { get; set;}
    public List<Item> SubItems { get; set;} = new();
    public List<Operation> Operations { get; set;} = new();
}