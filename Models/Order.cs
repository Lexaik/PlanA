namespace PlanA.Models;

public class Order
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Dictionary<Product, int> Products { get; set; } = new();
}