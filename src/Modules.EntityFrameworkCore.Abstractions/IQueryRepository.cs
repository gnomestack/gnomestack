using Gnome.Sys;

namespace Gs.Modules.EntityFrameworkCore.Abstractions;

public interface IQueryRepository<TModel>
    where TModel : class
{
    public IQueryable<TModel> Set { get; }

    public Task<Result<TModel>> CreateAsync(TModel model, CancellationToken cancellationToken = default);

    public Task<Result<TModel>> UpdateAsync(TModel model, CancellationToken cancellationToken = default);

    public Task<Result<TModel>> DeleteAsync(TModel model, CancellationToken cancellationToken = default);
}