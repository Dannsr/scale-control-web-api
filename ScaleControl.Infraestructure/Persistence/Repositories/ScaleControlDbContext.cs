using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScaleControl.Core.Entities;

namespace ScaleControl.Infraestructure.Persistence;

public class ScaleControlDbContext : DbContext
{
    public ScaleControlDbContext(DbContextOptions<ScaleControlDbContext> options) : base(options)
    {
    }
    public DbSet<Scale> Scales { get; set; }
    public DbSet<Detachment> Detachments { get; set; }
    public DbSet<Restriction> Restrictions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}