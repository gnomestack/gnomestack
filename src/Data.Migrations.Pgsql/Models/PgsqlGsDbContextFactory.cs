using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gs.Data.Models;

public class PgsqlGsDbContextFactory : IDesignTimeDbContextFactory<PgsqlGsDbContext>
{
    public PgsqlGsDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<PgsqlGsDbContext>();
        builder.UseNpgsql("Host=localhost;Database=gs_test;Username=postgres;Password=Password1234;");
        builder.UseSnakeCaseNamingConvention();
        return new PgsqlGsDbContext(builder.Options);
    }
}