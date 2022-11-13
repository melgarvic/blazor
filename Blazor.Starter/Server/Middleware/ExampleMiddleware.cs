using System.Globalization;

namespace Blazor.Starter.Server.Middleware
{
    public class ExampleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExampleMiddleware> _logger;

        private readonly string COOLMODE_HEADER = "COOLMODE";

        public ExampleMiddleware(RequestDelegate next, ILogger<ExampleMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // This middleware will set culture info for the duration of this request on its way through the pipeline

        public async Task InvokeAsync(HttpContext context)
        {
            var cool = context.Request.Headers[COOLMODE_HEADER];
            if (!string.IsNullOrEmpty(cool))
            {
                _logger.LogWarning("cool MODE HAS BEEN ENABLED");
                _logger.LogWarning(cool);
            }

            var cultureQuery = context.Request.Query["culture"]; // grab from query-string
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            _logger.LogInformation("Current culture is: " + CultureInfo.CurrentCulture.Name);

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }

    public static class ExampleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExampleMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware<ExampleMiddleware>();
    }
}
