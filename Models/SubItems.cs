namespace PlanA.Models;

public class SubItems
{
    public required Guid ItemId { get; set;}
    public Item? Item { get; set; }
    public required Guid SubItemId { get; set;}
    public Item? SubItem { get; set; }
    public required int Quantity { get; set;}
}