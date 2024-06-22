using System.ComponentModel.DataAnnotations;

using Gnome.Sys;

using Gs.Modules.Sec.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Riok.Mapperly.Abstractions;

namespace Gs.Modules.Sec.Stores;

public class ReleaseEnvironmentStore
{
    private SecDbContext Db { get; }
    
    private ILogger<ReleaseEnvironmentStore> Logger { get;  }

    private DbSet<ReleaseEnvironmentTable> Set { get; }

    private ReleaseEnvironmentMapper Mapper { get; } = new();

    public async Task<Response<ReleaseEnvironment>> CreateAsync(ReleaseEnvironment model, CancellationToken cancellationToken = default)
    {
        
        try
        {
            var table = this.Mapper.Map(model);
            this.Set.Add(table);
            await this.Db.SaveChangesAsync(cancellationToken).NoCap();
            model.Id = table.Id;
            return model;
        }
        catch (ValidationException ex)
        {
            this.Logger.LogError(ex, "Validation failed for release environment {ReleaseEnvironment}", model.Key);
            return ex;
        }
        catch (Exception ex)
        {
            this.Logger.LogError(ex, "Unexpected error occurred while creating release environment {ReleaseEnvironment}", model.Key);
            return ex;
        }
    }

    public async Task<Result<ReleaseEnvironment>> UpdateAsync(ReleaseEnvironment model, CancellationToken cancellationToken = default)
    {
        var table = this.Mapper.Map(model);
        this.Set.Update(table);
        await this.Db.SaveChangesAsync(cancellationToken).NoCap();
        return model;
    }
}

[Mapper]
public partial class ReleaseEnvironmentMapper
{
    public partial ReleaseEnvironmentTable Map(ReleaseEnvironment model);

    public partial ReleaseEnvironment Map(ReleaseEnvironmentTable table);
}