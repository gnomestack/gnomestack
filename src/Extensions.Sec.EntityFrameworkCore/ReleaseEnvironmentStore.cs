using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using Gnome.Extensions.FluentValidation;
using Gnome.Sys;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gnome.Extensions.Sec;

public class ReleaseEnvironmentStore<[Dam(DamitCommon.EfEntity)]TReleaseEnvironment, TContext, [Dam(Damit.All)] TKey> : ReleaseEnvironmentStoreBase<TReleaseEnvironment, TKey>
    where TReleaseEnvironment : ReleaseEnvironment<TKey>, new()
    where TKey : IEquatable<TKey>
    where TContext : DbContext
{

    protected ReleaseEnvironmentStore(TContext dbContext, ILogger logger)
    {
        this.DbContext = dbContext;
        this.ReleaseEnvironmentSet = dbContext.Set<TReleaseEnvironment>();
        this.Logger = logger;
    }

    public IQueryable<TReleaseEnvironment> ReleaseEnvironments => this.ReleaseEnvironmentSet;

    protected DbSet<TReleaseEnvironment> ReleaseEnvironmentSet { get; }

    protected TContext DbContext { get; }
    
    protected ILogger Logger { get; }
    
    /// <summary>
    /// Converts the provided <paramref name="id"/> to a strongly typed key object.
    /// </summary>
    /// <param name="id">The id to convert.</param>
    /// <returns>An instance of <typeparamref name="TKey"/> representing the provided <paramref name="id"/>.</returns>
    [UnconditionalSuppressMessage(
        "Trimming", 
        "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code",
        Justification = "TKey is annotated with RequiresUnreferencedCodeAttribute.All.")]
    public virtual TKey? ConvertIdFromString(string? id)
    {
        if (id == null)
            return default;

        return (TKey?)TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(id);
    }

    /// <summary>
    /// Converts the provided <paramref name="id"/> to its string representation.
    /// </summary>
    /// <param name="id">The id to convert.</param>
    /// <returns>An <see cref="string"/> representation of the provided <paramref name="id"/>.</returns>
    public virtual string? ConvertIdToString(TKey id)
    {
        if (object.Equals(id, default(TKey)))
            return null;

        return id.ToString();
    }

    public override async Task<Response<TReleaseEnvironment>> CreateAsync(TReleaseEnvironment releaseEnvironment, CancellationToken cancellationToken = default)
    {
        try
        {
            var validator = new ReleaseEnvironmentValidator<TKey>();
            var r = await validator.ValidateAsync(releaseEnvironment, cancellationToken).NoCap();
            if (!r.IsValid)
                return (ValidationError)r;

            this.ReleaseEnvironmentSet.Add(releaseEnvironment);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return releaseEnvironment;
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex, "Error creating release environment {ReleaseEnvironment}", releaseEnvironment.Key);
            return new Error($"Unexpected error creating release environment: {ex.Message}");
        }
    }

    public override  async Task<Response<TReleaseEnvironment>> UpdateAsync(TReleaseEnvironment releaseEnvironment, CancellationToken cancellationToken = default)
    {
        try
        {
            var validator = new ReleaseEnvironmentValidator<TKey>();
            var r = await validator.ValidateAsync(releaseEnvironment, cancellationToken).NoCap();
            if (!r.IsValid)
                return (ValidationError)r;

            await this.DbContext.SaveChangesAsync(cancellationToken);
            return releaseEnvironment;
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex, "Error creating release environment {ReleaseEnvironment}", releaseEnvironment.Key);
            return new Error($"Unexpected error creating release environment: {ex.Message}");
        }
    }

    public override async Task<Response> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            var key = this.ConvertIdFromString(id);
            if (key is null || key.Equals(default(TKey)))
            {
                this.Logger.LogInformation("Release environment key is not a valid id: {Id}", id);
                return Response.Fail(new Error($"Release environment cannot be deleted because of an invalid id {id}"));
            }

            var releaseEnvironment = await this.ReleaseEnvironmentSet.FindAsync(new object[] { key }, cancellationToken);
            if (releaseEnvironment is null)
                return Response.Ok();

            this.ReleaseEnvironmentSet.Remove(releaseEnvironment);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return Response.Ok();
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex, "Error deleting release environment {Id}", id);
            return Response.Fail(new Error($"Unexpected error deleting release environment: {ex.Message}"));
        }
    }

    public override async Task<Response> DeleteAsync(TReleaseEnvironment releaseEnvironment, CancellationToken cancellationToken = default)
    {
        try
        {
            this.ReleaseEnvironmentSet.Remove(releaseEnvironment);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return Response.Ok();
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex, "Error deleting release environment {ReleaseEnvironment}", releaseEnvironment.Key);
            return Response.Fail(ex);
        }
    }

    public override async Task<Response<TReleaseEnvironment>> FindByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var key = this.ConvertIdFromString(id);
        if (key is null || key.Equals(default(TKey)))
        {
            this.Logger.LogInformation("Release environment key is not a valid id: {Id}", id);
            return new Error("Release environment key is not a valid id");
        }

        return await this.ReleaseEnvironmentSet.FindAsync(new object[] { key }, cancellationToken)
    }

    public override Task<Response<TReleaseEnvironment>> FindByKeyAsync(string key, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<PagedResponse<TReleaseEnvironment>> PageAsync(ContinuationToken? token = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}