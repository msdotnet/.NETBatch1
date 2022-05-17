using System;
using HelloWorldVs.ArithmeticLibrary;
using Humanizer;

namespace HelloWorldVs // Note: actual namespace depends on the project name.
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Divide a by b and the result is " + ArithmeticOperation.DivideNumber(15,4));
         Console.WriteLine("Show me Date: " + HumanizeDate());
         Console.ReadLine();
      }
      static string HumanizeDate()
      {
         return DateTime.Now.AddDays(-5).Humanize();
      }
   }
}