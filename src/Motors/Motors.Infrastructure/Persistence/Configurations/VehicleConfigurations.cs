using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motors.Domain.Aggregates.VehicleAggregate;

namespace Motors.Infrastructure.Persistence.Configurations;

public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle> 
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(v => v.Brand)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Model)
            .HasMaxLength(50);
        
        builder.HasIndex(v => new {v.Brand, v.Model}).IsUnique();
    }
}