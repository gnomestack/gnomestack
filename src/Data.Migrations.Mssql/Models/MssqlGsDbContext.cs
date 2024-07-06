using Microsoft.EntityFrameworkCore;

namespace Gs.Data.Models;

public class MssqlGsDbContext : GsDbContext
{
    public MssqlGsDbContext(DbContextOptions<MssqlGsDbContext> options)
        : base(options)
    {
    }
}