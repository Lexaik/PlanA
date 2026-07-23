using Microsoft.EntityFrameworkCore;
using PlanA.ModelConfigurations;
using PlanA.Models;

namespace PlanA.Context;

public class PlanADbContext : DbContext
{
    public DbSet<Asset> assets { get; set; } = null!;
    public DbSet<Operation> operations { get; set; } = null!;
    public DbSet<Order> orders { get; set; } = null!;
    public DbSet<OrderItems> order_items { get; set; } = null!;
    public DbSet<Process> processes { get; set; } = null!;
    public DbSet<Sub_Process> sub_processes { get; set; } = null!;
    public DbSet<SubItems> sub_items { get; set; } = null!;
    public DbSet<Person> persons { get; set; } = null!;
    public DbSet<Employee> employees { get; set; } = null!;
    public DbSet<Equipment> equipments { get; set; } = null!;

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
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.Entity<Asset>()
            .HasOne(i => i.Item)
            .WithOne(a => a.Asset)
            .HasForeignKey<Item>(it => it.Id)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Asset>().ToTable("assets");
        modelBuilder.Entity<Item>().ToTable("assets");
        
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OperationItemsConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
        modelBuilder.ApplyConfiguration(new SubItemsConfiguration());
        modelBuilder.ApplyConfiguration(new SubprocessConfiguration());
    }
}