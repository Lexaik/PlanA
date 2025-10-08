using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Item
{
    public int ItemId { get; init;}
    public required string Name { get; set;}
    public List<Item> SubItems { get; set;} = new();
    public List<Operation> Operations { get; set;} = new();
    public List<Order> Orders { get; set;} = new();
    public List<Sub_items> ItemSubitems { get; set;} = new();
    public List<Operation_items> OperationItems { get; set;} = new();
    public List<Order_items> OrderItems { get; set;} = new();
}