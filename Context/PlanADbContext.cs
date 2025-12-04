using Microsoft.EntityFrameworkCore;
using PlanA.ModelConfigurations;
using PlanA.Models;

namespace PlanA.Context;

public class PlanADbContext : DbContext
{
    public DbSet<Asset> Assets { get; set; } = null!;
    public DbSet<Operation> Operations { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Order_items> OrderItems { get; set; } = null!;
    public DbSet<Process> Processes { get; set; } = null!;
    public DbSet<Sub_process> SubProcesses { get; set; } = null!;
    public DbSet<Sub_items> SubItems { get; set; } = null!;

    public PlanADbContext(DbContextOptions<PlanADbContext> options)
        : base(options) {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            //.SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>()
            .HasOne(i => i.Item)
            .WithOne(a => a.Asset)
            .HasForeignKey<Item>(it => it.Id)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Asset>().ToTable("Assets");
        modelBuilder.Entity<Item>().ToTable("Assets");
        
        modelBuilder.ApplyConfiguration(new OperationItemsConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
        modelBuilder.ApplyConfiguration(new SubItemsConfiguration());
        modelBuilder.ApplyConfiguration(new SubprocessConfiguration());
    }
}