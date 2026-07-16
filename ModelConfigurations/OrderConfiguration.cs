using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order> {
    public void Configure(EntityTypeBuilder<Order> builder) {
        builder.ToTable("orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Name).IsRequired();
        builder.Property(o => o.OrderCreated);
        builder.Property(o => o.PlanDateStart);
        builder.Property(o => o.PlanDateEnd);
        builder.Property(o => o.ActualDateStart);
        builder.Property(o => o.ActualDateEnd);
        builder.Property(o => o.IsActive);
        builder.Ignore(o => o.OrderItems);
        
        /*builder.OwnsMany(o => o.OrderItems, ownedBuilder => {
            ownedBuilder.ToTable("OrderItems");
            ownedBuilder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");
            ownedBuilder.HasKey("Id");
            ownedBuilder.WithOwner()
                .HasForeignKey("OrderId");
            ownedBuilder.Property(i => i.ItemId)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("ItemName");
            ownedBuilder.Property(i => i.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");
            ownedBuilder.HasIndex("OrderId");
            ownedBuilder.HasIndex("OrderId")
                .IsUnique();
        });*/
    }
}