using System;
using System.Threading.Tasks;

namespace TemperatureConverter
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Family family = new Family();
         Family.Count = 10;
         Family family1 = new Family();
         Family family2 = new Family();
         Family family3 = new Family();
         Family family4 = new Family();
         Console.WriteLine($"Total Instance: {Family.Count} {family3.Count1}");
      }
   }

   class Family
   {
      public static int Count = 0;
      public int Count1 = 0;
      public Family()
      {
         Count++;
         Count1++;
      }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
      //public static string GetName() => "Chulbul" + GetFullName();
      //public string GetFullName() => $"{GetName()} Pandey";
      public async Task<string> GetNameAsync()
      {
         if(false)
         {
            ;
         }
         await Task.Delay(3000);
         return "Chulbul";
      }
   }
}
