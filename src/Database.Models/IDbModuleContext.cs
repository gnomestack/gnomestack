using Microsoft.EntityFrameworkCore;

namespace Gs.Database.Models;

public interface IDbModuleContext
{
    DbSet<T> Set<T>()
        where T : class;

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}