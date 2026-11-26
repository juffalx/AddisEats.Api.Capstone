public class CorreletionIdMiddleware
{
    // di injection እንፈጥራለን ምክንያቱም next ምትባለውን ወደቀጣይ ሚድልዌር ምታዘዋውረውን ስለምንፈልጋት
    private readonly RequestDelegate _next;
    private readonly ILogger<CorreletionIdMiddleware> _logger;
    // 
    public CorreletionIdMiddleware(RequestDelegate next, ILogger<CorreletionIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 1, correlation ID መቀበል ከሌለ ወይም ካልተላከ ደግሞ አዲስ ክሬት ማድረግ የመጀመሪያ step
        var id = context.Request.Headers["X-Correlation-Id"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(id))
        {
            id = Guid.NewGuid().ToString("N");
        }
        // 2, TraceIdentifier ሚባለው ላይ ማስቀመጥ አለብን
        context.TraceIdentifier = id;

        // 3, response ሲመለስ እሱ ላይ ማስቀመጥ አለብን
        context.Response.Headers["X-Correlation-Id"] = context.TraceIdentifier;

        using (_logger.BeginScope(new Dictionary<string, object>
        {
            ["CorrelationId"] = id,
            ["Path"] = context.Request.Path.Value!
        }))

        // 4, ወደ ቀጣዩ middleWare እንዲሄድ
        {
            await _next(context);
        }
    }
}