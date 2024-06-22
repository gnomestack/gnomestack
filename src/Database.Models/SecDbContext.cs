using Microsoft.EntityFrameworkCore;

namespace Gs.Database.Models;

// Secrets, Environments, and Configurations
public class SecDbContext : DbContext
{
    public SecDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<ReleaseEnvironment> ReleaseEnvironments { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("gs_db");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseReleaseEnvironment();
        base.OnModelCreating(modelBuilder);
    }
}