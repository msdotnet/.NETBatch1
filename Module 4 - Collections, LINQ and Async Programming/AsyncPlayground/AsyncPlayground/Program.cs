using AsyncPlayground.Library;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncPlayground
{
   internal class Program
   {
      static async Task Main(string[] args)
      {
         var networkService = new NetworkService();
         var webStringTask = networkService.ReadWebAsStringAsync(); //  Async - returns Task<string>
         var stringHtmlSync = networkService.ReadWebAsString();
         var findNetTask = networkService.FindNetFromWebResultAsync(stringHtmlSync); // Async - returns Task<int>
         Console.WriteLine("Web String async task started on worker thread");
         Console.WriteLine(stringHtmlSync);

         //await Task.WhenAll(webStringTask, findNetTask);
         var taskCollection = new List<Task>();
         taskCollection.Add(findNetTask);
         taskCollection.Add(findNetTask);

         await Task.WhenAll(taskCollection);

         //while (taskCollection.Count > 0)
         //{
         //   var task = await Task.WhenAny(taskCollection);
         //   if (task == webStringTask)
         //   {
         //      Console.WriteLine("Web String Task has been finished")
         //   }
         //   else if (task == findNetTask)
         //   {
         //      Console.WriteLine("Find Net Task has been finished");
         //   }
         //}



         Console.WriteLine(webStringTask.Result);

         Console.WriteLine(findNetTask.Result);
         Console.WriteLine("Operation after async call");
      }
   }
}
