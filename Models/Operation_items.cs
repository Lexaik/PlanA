using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public enum OperationItemType {Sources, Supplies, Product, Remains}
public class Operation_items
{
    public int OperationId { get; set; }
    public Operation? Operation { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public OperationItemType OperationItemType { get; set; }
    public int Quantity { get; set; }
}