using Gnome.Sys;

using Microsoft.EntityFrameworkCore;

namespace Gs.Modules.EntityFrameworkCore.Abstractions;

public abstract class EfQueryRepository<TModel> : IEfQueryRepository<TModel>
    where TModel : class
{
    protected EfQueryRepository(DbContext db)
    {
        this.Db = db;
        this.Set = db.Set<TModel>();
    }

    IQueryable<TModel> IQueryRepository<TModel>.Set => this.Set;

    public DbSet<TModel> Set { get; }

    protected DbContext Db { get; }


    public virtual async Task<Result<TModel>> CreateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            this.Set.Add(model);
            await this.Db.SaveChangesAsync(cancellationToken).NoCap();
            return model;
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public async Task<Result<TModel>> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            await this.Db.SaveChangesAsync(cancellationToken).NoCap();
            return model;
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public async Task<Result<TModel>> DeleteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            this.Set.Remove(model);
            await this.Db.SaveChangesAsync(cancellationToken).NoCap();
            return model;
        }
        catch (Exception e)
        {
            return e;
        }
    }
}