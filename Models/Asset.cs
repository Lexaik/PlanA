using Microsoft.EntityFrameworkCore;

namespace PlanA.Models;

public class Asset {
    public int Id { get; set; }
    public required int Quantity { get; set; }
    
    public Item? Item { get; set; }
}