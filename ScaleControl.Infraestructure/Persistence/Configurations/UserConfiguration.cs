using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleControl.Core.Entities;

namespace ScaleControl.Infraestructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasMany(s => s.Scales).WithOne().HasForeignKey(s => s.IdScale).OnDelete(DeleteBehavior.Restrict);

    }
}