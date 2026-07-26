namespace PlanA.Models;

public class OrderItems {
    public Guid OrderId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    
    public Order? Order { get; set; }
    public Item? Item { get; set; }
}