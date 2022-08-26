using EmployeeRecordBook.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddEventLog();

builder.Services.RegisterSystemServices();
builder.Services.RegisterApplicationServices();



var app = builder.Build();

app.CreateMiddlewarePipeline();

app.Run();
