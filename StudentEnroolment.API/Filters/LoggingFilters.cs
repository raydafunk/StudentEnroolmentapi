namespace StudentEnroolment.API.Filters
{
    public class LoggingFilters : IEndpointFilter
    {
        private readonly ILogger _logger;

        public LoggingFilters(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<LoggingFilters>();
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;

            _logger.LogInformation("{method} request made to {path}", method, path);

            try
            {
                var result = await next(context);

                _logger.LogInformation("{method} request made to {path} successful", method, path);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{method} request to {path} failed", method, path);
                return Results.Problem("An error has occured, please try again later");
            }
        }
    }
}
