using Microsoft.EntityFrameworkCore;

namespace Gs.Data.Models;

public class PgsqlGsDbContext : GsDbContext
{
    public PgsqlGsDbContext(DbContextOptions<PgsqlGsDbContext> options)
        : base(options)
    {
    }
}