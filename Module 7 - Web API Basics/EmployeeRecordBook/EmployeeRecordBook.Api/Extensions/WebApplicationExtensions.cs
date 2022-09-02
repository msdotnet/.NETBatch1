using Serilog;

namespace EmployeeRecordBook.Api.Extensions
{
   public static class WebApplicationExtensions
   {
      public static void CreateMiddlewarePipeline(this WebApplication app)
      {
         // Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }
         app.UseResponseCompression();
         app.UseHttpsRedirection();

         app.UseSerilogRequestLogging();

         app.UseAuthorization();

         app.MapControllers();
      }
   }
}
