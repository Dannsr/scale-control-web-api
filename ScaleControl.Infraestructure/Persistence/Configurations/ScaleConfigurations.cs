using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleControl.Core.Entities;

namespace ScaleControl.Infraestructure.Persistence.Configurations;

public class ScaleConfigurations : IEntityTypeConfiguration<Scale>
{

    public void Configure(EntityTypeBuilder<Scale> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasMany(s => s.Offices).WithOne().HasForeignKey(u => u.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
    }
}