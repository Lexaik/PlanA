namespace PlanA.Models;

public class Product
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public Dictionary<Product, int> SubProducts { get; set;} = new();
    public List<Operation> Operations { get; set;} = new();
}