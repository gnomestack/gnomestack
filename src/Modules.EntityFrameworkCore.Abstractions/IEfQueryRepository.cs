using Microsoft.EntityFrameworkCore;

namespace Gs.Modules.EntityFrameworkCore.Abstractions;

public interface IEfQueryRepository<TModel> : IQueryRepository<TModel>
    where TModel : class
{
    new DbSet<TModel> Set { get; }
}