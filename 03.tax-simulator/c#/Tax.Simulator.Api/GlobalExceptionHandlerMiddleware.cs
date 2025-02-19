namespace Tax.Simulator.Api;

/// <summary>
/// Middleware permettant la gestion des exceptions
/// </summary>
/// <param name="next"> prochaine instance de middleware</param>
/// <param name="logger">Log des exceptions</param>
public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    /// <summary>
    /// Invoque le middleware pour gérer le contexte http
    /// </summary>
    /// <param name="context">Contexte HTTP</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync(
                $"An unexpected error occurred. Please try again later.{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace}"
            );
        }
    }
}