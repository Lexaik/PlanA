using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

//public enum OperationItemType {Sources, Supplies, Product, Remains}
public class OperationItems
{
    public Guid OperationId { get; set; }
    public Operation? Operation { get; set; }
    public Guid ItemId { get; set; }
    public Item? Item { get; set; }
    public required string ItemType { get; set; }
    public int Quantity { get; set; }
}