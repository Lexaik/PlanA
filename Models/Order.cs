using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanA.Models;

public class Order {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public required string Name { get; set; }
    public DateTime OrderCreated { get; set; } = DateTime.Now;
    public DateTime PlanDateStart { get; set; }
    public DateTime PlanDateEnd { get; set; }
    public DateTime? ActualDateStart { get; set; }
    public DateTime? ActualDateEnd { get; set; }
    public bool IsActive { get; set; } = true;
    
    public List<Item> Items { get; set; } = new();
    public List<OrderItems> OrderItems { get; set;} = new();

    private Dictionary<Guid, int> OrderItemQuantity
    {
        get => OrderItems.ToDictionary(o => o.ItemId, o => o.Quantity);
        set => OrderItems = value.Select(kvp => new OrderItems
        {
            OrderId = Id,
            ItemId = kvp.Key,
            Quantity = kvp.Value
        }).ToList();
    }
}