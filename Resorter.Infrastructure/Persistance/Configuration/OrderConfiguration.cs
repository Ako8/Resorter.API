using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class OrderConfiguration : BaseConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        builder.HasOne(o => o.Car)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.CarId);

        builder.HasOne(o => o.PickupAddress)
            .WithMany(a => a.PickupOrders)
            .HasForeignKey(o => o.PickupAddressId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(o => o.DropoffAddress)
            .WithMany(a => a.DropoffOrders)
            .HasForeignKey(o => o.DropoffAddressId)
            .OnDelete(DeleteBehavior.Restrict); 

    }
}
