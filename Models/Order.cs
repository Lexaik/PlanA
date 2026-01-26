namespace PlanA.Models;

public class Order {
    public int Id { get; init; }
    public required string Name { get; set; }
    public DateTime PlanDateStart { get; set; }
    public DateTime PlanDateEnd { get; set; }
    public DateTime? ActualDateStart { get; set; }
    public DateTime? ActualDateEnd { get; set; }
    public bool IsActive { get; set; }
    
    public List<Item> Items { get; set; } = new();
    public List<Order_items> OrderItems { get; set;} = new();
}