namespace Core.Features.Test;

public sealed class Create : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MapPost("api/test", async (CreateHandler handler) => await handler.Handle());
    }
}

public sealed class CreateHandler
{
    public async Task Handle()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}