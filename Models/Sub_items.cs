namespace PlanA.Models;

public class Sub_items
{
    public required int ItemId { get; set;}
    public Item? Item { get; set; }
    public required int SubItemId { get; set;}
    public Item? SubItem { get; set; }
    public required int Quantity { get; set;}
}