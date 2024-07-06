using Gs.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gs.Data.Models;

public class SqliteGsDbContextFactory : IDesignTimeDbContextFactory<SqliteGsDbContext>
{
    public SqliteGsDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SqliteGsDbContext>();
        builder.UseSqlite("Data Source=gs_test.db");
        builder.UseSnakeCaseNamingConvention();
        return new SqliteGsDbContext(builder.Options);
    }
}