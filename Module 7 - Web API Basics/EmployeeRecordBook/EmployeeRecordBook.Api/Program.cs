using EmployeeRecordBook.Api.Extensions;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));



builder.Logging.ClearProviders();
builder.Logging.AddEventLog();

builder.Services.AddSystemServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddAppSettings(builder.Configuration);

var app = builder.Build();

app.CreateMiddlewarePipeline();

app.Run();
