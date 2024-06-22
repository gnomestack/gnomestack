using FastEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using ProblemDetails = FastEndpoints.ProblemDetails;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace Gs.ApiSvc.Routes.Secrets;

public class NewSecretEndpoint : Endpoint<NewSecretReq, Results<Ok<NewSecretResp>, ProblemDetails>>
{
    public override void Configure()
    {
        this.Routes("api/secrets/new");
        this.Post();
        base.Configure();
    }

    public override Task<NewSecretResp> HandleAsync(NewSecretReq request, CancellationToken cancellationToken)
    {
        var secret = new NewSecretResp
        {
            Id = 1,
            Key = request.Key,
            Value = request.Value,
            ExpiresAt = request.ExpiresAt,
            IsEnabled = request.IsEnabled,
        };

        return Task.FromResult(secret);
    }
}

public class NewSecretReq
{
    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime? ExpiresAt { get; set; }

    public bool IsEnabled { get; set; }
}

public class NewSecretResp
{
    public int Id { get; set; }

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime? ExpiresAt { get; set; }

    public bool IsEnabled { get; set; }
}