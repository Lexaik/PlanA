using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Item {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required string Name { get; set;}
    
    public Asset? Asset { get; set;}
    public List<Item> SubItems { get; set;} = new();
    public List<Operation> Operations { get; set;} = new();
    public List<Order> Orders { get; set;} = new();
    public List<SubItems> ItemSubitems { get; set;} = new();
    public List<OperationItems> OperationItems { get; set;} = new();
    public List<OrderItems> OrderItems { get; set;} = new();
}