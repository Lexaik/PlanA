using Microsoft.EntityFrameworkCore;
using PlanA.Models;

namespace PlanA.Context;

public class PlanADbContext : DbContext
{
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<Operation_sources> OperationComponents { get; set; } = null!;
    public DbSet<Operation_remains> OperationRemains { get; set; } = null!;
    public DbSet<Operation_results> OperationResults { get; set; } = null!;
    public DbSet<Operation_supplies> OperationSupplies { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Order_items> OrderItems { get; set; } = null!;
    public DbSet<Process> Processes { get; set; } = null!;
    public DbSet<Sub_items> SubItems { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            //.SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    }
}