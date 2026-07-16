using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class SubItemsConfiguration : IEntityTypeConfiguration<SubItems>
{
    public void Configure(EntityTypeBuilder<SubItems> builder)
    {
        builder.ToTable("sub_items");
        builder.HasKey(o => new { o.ItemId, o.SubItemId });
        builder.Property(o => o.Quantity).IsRequired();
            
        builder.HasOne(i => i.Item)
            .WithMany(s => s.ItemSubitems)
            .HasForeignKey(i => i.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}