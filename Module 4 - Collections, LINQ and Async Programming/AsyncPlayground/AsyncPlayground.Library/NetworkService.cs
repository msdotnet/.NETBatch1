using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsyncPlayground.Library
{
   public class NetworkService
   {
      private readonly HttpClient _client;
      public NetworkService()
      {
         _client = new HttpClient();
         _client.BaseAddress = new Uri("https://devblogs.microsoft.com/dotnet/");
      }
      public string ReadWebAsString()
      {
         Task.Delay(3000).Wait();
         return _client.GetStringAsync(_client.BaseAddress).GetAwaiter().GetResult();
      }
      public async Task<string> ReadWebAsStringAsync()
      {
         await Task.Delay(5000);
         return await _client.GetStringAsync(_client.BaseAddress);
      }
      public async Task<int> FindNetFromWebResultAsync(string htmlString)
      {
         return await Task.Run(() => Regex.Match(htmlString, "NET").Length);
      }

   }
}
