using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gs.Data.Models;

public class MssqlGsDbContextFactory : IDesignTimeDbContextFactory<MssqlGsDbContext>
{
    public MssqlGsDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<MssqlGsDbContext>();
        builder.UseSqlServer("Server=localhost;Database=gs_test;User Id=sa;Password=Password1234;");
        builder.UseSnakeCaseNamingConvention();
        return new MssqlGsDbContext(builder.Options);
    }
}