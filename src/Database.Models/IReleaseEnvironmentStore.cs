using Microsoft.EntityFrameworkCore;

namespace Gs.Database.Models;

public interface IReleaseEnvironmentStore : IDbModuleContext
{
    DbSet<ReleaseEnvironment> ReleaseEnvironments { get;  }
}

