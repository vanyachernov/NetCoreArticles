namespace NetCoreArticles.Api.Middleware;

public class TaskCancellationHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TaskCancellationHandlingMiddleware> _logger;

    public TaskCancellationHandlingMiddleware(RequestDelegate next, ILogger<TaskCancellationHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception _) when (_ is OperationCanceledException or TaskCanceledException)
        {
            _logger.LogInformation("Task has been cancelled!");
        }
    }
}