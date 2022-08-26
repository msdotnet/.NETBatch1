using EmployeeRecordBook.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddEventLog();

builder.Services.AddSystemServices();
builder.Services.AddApplicationServices();



var app = builder.Build();

app.CreateMiddlewarePipeline();

app.Run();
