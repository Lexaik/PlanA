using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class SubItemsConfiguration : IEntityTypeConfiguration<Sub_items>
{
    public void Configure(EntityTypeBuilder<Sub_items> builder)
    {
        builder.ToTable("Sub_Items");
        builder.HasKey(o => new { o.ItemId, o.SubItemId });
        builder.Property(o => o.Quantity).IsRequired();
            
        builder.HasOne(i => i.Item)
            .WithMany(s => s.ItemSubitems)
            .HasForeignKey(i => i.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}