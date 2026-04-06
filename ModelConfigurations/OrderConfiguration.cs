using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order> {
    public void Configure(EntityTypeBuilder<Order> builder) {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("int");
        builder.Property(o => o.OrderCreated)
            .IsRequired()
            .HasColumnType("datetime2");
        builder.Ignore(o => o.OrderItems);
        builder.OwnsMany(o => o._items, ownedBuilder =>
        {
            ownedBuilder.ToTable("OrderItems");
            
            // Теневой первичный ключ с автоинкрементом
            ownedBuilder.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");
            
            ownedBuilder.HasKey("Id");
            
            // Внешний ключ
            ownedBuilder.WithOwner()
                .HasForeignKey("OrderId");
            
            // Настройка свойств
            ownedBuilder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("ItemName");
            
            ownedBuilder.Property(i => i.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");
            
            // Индекс для ускорения запросов
            ownedBuilder.HasIndex("OrderId");
            
            // Уникальный индекс для предотвращения дубликатов
            ownedBuilder.HasIndex("OrderId", "Name")
                .IsUnique();
        });
    }
}