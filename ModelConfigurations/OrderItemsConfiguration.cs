using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
{
    public void Configure(EntityTypeBuilder<OrderItems> builder)
    {
        builder.ToTable("order_items");
        builder.HasKey(o => new { o.ItemId, o.OrderId });
        builder.Property(o => o.Quantity).IsRequired();
            
        builder.HasOne(i => i.Item)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(i => i.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(o => o.Order)
            .WithMany(i => i.OrderItems)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}