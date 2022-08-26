using EmployeeRecordBook.Core.Infrastructure.Repositories;
using EmployeeRecordBook.Infrastructure.Data;
using EmployeeRecordBook.Infrastructure.Repositories.Dapper;
using EmployeeRecordBook.Infrastructure.Repositories.EntityFramework;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeRecordBook.Api.Extensions
{
   public static class ServiceCollectionsExtensions
   {
      public static void RegisterSystemServices(this IServiceCollection services)
      {
         // Add services to the container.
         services.AddControllers();
         // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
         services.AddEndpointsApiExplorer();
         services.AddSwaggerGen();
         services.AddAutoMapper(typeof(Program));
         //services.AddDbContext<EmployeeContext>();
         services.AddScoped<IDbConnection>(option => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDb"));
      }
      public static void RegisterApplicationServices(this IServiceCollection services)
      {
         //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
         services.AddScoped<IEmployeeRepository, EmployeeDapperRepository>();
      }
   }
}
