using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motors.Domain.Aggregates.VehicleAggregate;

namespace Motors.Infrastructure.Persistence.Configurations;

public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle> 
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id).ValueGeneratedOnAdd();

        builder.Property(v => v.Brand).HasMaxLength(50).IsRequired();
    }
}