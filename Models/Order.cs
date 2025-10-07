namespace PlanA.Models;

public class Order
{
    public int OrderId { get; init; }
    public required string Name { get; set; }
    public List<Item> Items { get; set; } = new();
    public List<Order_items> OrderItems { get; set;} = new();
}