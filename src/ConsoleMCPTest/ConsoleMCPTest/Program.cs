using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});
builder.Services.Configure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(Program).Assembly);
await builder.Build().RunAsync();

[McpServerToolType]
public sealed class Tools
{
    private readonly ILogger<Tools> _logger;

    public Tools(ILogger<Tools> logger)
    {
        _logger = logger;
    }

    [McpServerTool, Description("Echoes the message back to the client in reverse.")]
    public string Echo(string message)
    {
        _logger.LogInformation("Echo tool called with message: {Message}", message);
        return $"hello {new string(message.Reverse().ToArray())}";
    }

    [McpServerTool, Description("Calculates the sum of two numbers.")]
    public double CalculateSum(double a, double b)
    {
        _logger.LogInformation("CalculateSum tool called with a={A}, b={B}", a, b);
        return a + b;
    }

    [McpServerTool, Description("Returns the current server time.")]
    public string GetCurrentTime()
    {
        _logger.LogInformation("GetCurrentTime tool called");
        return DateTime.Now.ToString("F");
    }
}

