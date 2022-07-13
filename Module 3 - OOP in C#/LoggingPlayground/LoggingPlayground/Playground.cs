using Serilog;

namespace LoggingPlayground
{
   public class Playground
   {
      public static void PlayWithLogging()
      {
         Log.Information("This is my first logging on console and file simultaniously.");

         // Structured and un-structured logs:
         string provider = "Google";
         var position = new { Latitude = 25, Longitude = 134, Provider = provider };
         var elapsedMs = 34;
         Log.Information("Processed {@Position} in {Elapsed} ms.", position, elapsedMs);


         var fruits = new[] { "Apple", "Orange" };
         Log.Information("My fruit collection is: {Fruits}", fruits);


         // Logging Debug, Warning and Exception details
         int a = 10, b = 0;
         try
         {
            Log.Debug($"Dividing {a} by {b}");
            if (b == 0)
            {
               Log.Warning("You are trying to divide by zereo, it will result into failure.");
            }
            Console.WriteLine(a / b);
         }
         catch (DivideByZeroException ex)
         {
            Log.Error(ex, $"Something went wrong. Error: {ex.Message}");
         }
      }
   }
}
