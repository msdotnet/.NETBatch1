using Serilog;
using Serilog.Formatting.Json;
using LoggingPlayground;

// Instantiate and initialize the logger
Log.Logger = new LoggerConfiguration()
   .MinimumLevel.Debug()
   .WriteTo.Console()
   .WriteTo.File("logs/myloggingapp-human-readable.txt", rollingInterval: RollingInterval.Day)
   .WriteTo.File(new JsonFormatter(), "logs/myloggingapp-machine-readable.txt", rollingInterval: RollingInterval.Day)
   .CreateLogger();

Log.Information("Logger is intantiated and initialized.");


try
{
   Playground.PlayWithLogging();
}
finally
{
   Log.CloseAndFlush();
}

