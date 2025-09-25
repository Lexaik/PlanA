using Microsoft.EntityFrameworkCore;
using PlanA.Models;

namespace PlanA.Context;

public class PlanADbContext : DbContext
{
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<OperationComponents> OperationComponents { get; set; } = null!;
    public DbSet<OperationRemains> OperationRemains { get; set; } = null!;
    public DbSet<OperationResults> OperationResults { get; set; } = null!;
    public DbSet<OperationSupplies> OperationSupplies { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItems> OrderItems { get; set; } = null!;
    public DbSet<Process> Processes { get; set; } = null!;
    public DbSet<SubItems> SubItems { get; set; } = null!;
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConnectionString);
    }
}