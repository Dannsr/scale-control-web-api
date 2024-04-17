using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleControl.Core.Entities;

namespace ScaleControl.Infraestructure.Persistence.Configurations;

public class UserScaleConfiguration : IEntityTypeConfiguration<UserScale>
{
    public void Configure(EntityTypeBuilder<UserScale> builder)
    {
        builder.HasKey(u => u.Id);
    }
}