using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class OperationItemsConfiguration : IEntityTypeConfiguration<Operation_items>
{
    public void Configure(EntityTypeBuilder<Operation_items> builder)
    {
        builder.ToTable("Operation_Items");
            builder.HasKey(o => new { o.ItemId, o.OperationId });
            builder.Property(o => o.ItemType).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();
            
            builder.HasOne(i => i.Item)
                .WithMany(o => o.OperationItems)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(o => o.Operation)
                .WithMany(i => i.OperationItems)
                .HasForeignKey(o => o.OperationId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}