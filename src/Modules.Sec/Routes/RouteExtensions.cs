using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Gs.Modules.Sec.Routes;

public static class RouteExtensions
{
    public static void MapSecRoutes(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/sec", async context =>
        {
            await context.Response.WriteAsJsonAsync(new { Message = "Hello, Sec!" });
        });
    }
}