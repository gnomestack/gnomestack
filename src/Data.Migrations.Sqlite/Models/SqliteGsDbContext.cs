using Microsoft.EntityFrameworkCore;

namespace Gs.Data.Models;

public class SqliteGsDbContext : GsDbContext
{
    public SqliteGsDbContext(DbContextOptions<SqliteGsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        this.UseSchema = false;
        base.OnModelCreating(builder);
    }
}