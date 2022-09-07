using EmployeeRecordBook.Api.Configurations;
using EmployeeRecordBook.Api.Infrastructure.Configurations;
using EmployeeRecordBook.Core.AppSettings;
using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories.Dapper;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace EmployeeRecordBook.Api.Extensions
{
   public static class ServiceCollectionsExtensions
   {
      public static void AddSystemServices(this IServiceCollection services, IConfiguration configuration)
      {
         // Add services to the container.
         services.AddControllers();
         // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
         services.AddEndpointsApiExplorer();
         services.AddVersionedApiExplorer(setup =>
         {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
         });
         services.AddSwaggerGen();
         services.ConfigureOptions<ConfigureSwaggerOptions>();
         services.AddAutoMapper(typeof(MappingProfile).Assembly);
         services.AddDbContext<EmployeeContext>(option => option.UseSqlServer(configuration.GetConnectionString("EmployeeDbConnection")));
         services.AddDataProtection();
         services.AddResponseCompression(options =>
         {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
         });
         services.AddApiVersioning(options =>
         {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
         });
         //services.AddScoped<IDbConnection>(option => new SqlConnection(configuration.GetConnectionString("EmployeeDbConnection")));  // Enable when using Dapper
      }
      public static void AddApplicationServices(this IServiceCollection services)
      {
         services.AddScoped<IEmployeeRepository, EmployeeRepository>();
         //services.AddScoped<IEmployeeRepository, EmployeeDapperRepository>(); // Enable when using Dapper
      }

      public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
      {
         services.Configure<CommonOptions>(configuration.GetSection(CommonOptions.Common));

      }
   }
}
