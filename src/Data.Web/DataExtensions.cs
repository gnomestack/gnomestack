using Gs.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataExtensions
{
    public static WebApplication MapGsIdentityApi(this WebApplication builder)
    {
        builder.UseAuthorization();
        builder.MapGroup("/api/v1/iam").MapIdentityApi<IamUser>();
        return builder;
    }

    public static IServiceCollection AddGsDbContext(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder>? optionsAction = null,
        ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
    {
        services.AddDbContext<GsDbContext>(optionsAction, contextLifetime, optionsLifetime);
        services.AddIdentityApiEndpoints<IamUser>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequireUppercase = true;
                o.Password.RequiredLength = 12;
                o.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                o.Lockout.MaxFailedAccessAttempts = 5;
                o.Lockout.AllowedForNewUsers = true;

                // User settings.
                o.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<GsDbContext>();

        services.AddAuthorization();

        return services;
    }
}