using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNDirectoryPlayground
{
   public class DirectoryPlayground
   {
      public static void PlayWithDirectory()
      {
         var directoryInfo = Directory.CreateDirectory("FirstDirectory");
         Console.WriteLine(directoryInfo.FullName);
         //directoryInfo.Delete();
         //Directory.Delete(@"D:\Training\.NETBatch1\Module 3 - OOP in C#\FileNDirectoryPlayground\FileNDirectoryPlayground\bin\Debug\net6.0\FirstDirectory");
         //directoryInfo.MoveTo(@"D:\Training\.NETBatch1\Module 3 - OOP in C#\FileNDirectoryPlayground\FileNDirectoryPlayground\FirstDirectory");

         var destinationDirectory = @"D:\Training\.NETBatch1\Module 3 - OOP in C#\FileNDirectoryPlayground\FileNDirectoryPlayground\MovedDirectory";
         if (!Directory.Exists(destinationDirectory))
         {
            Directory.Move("FirstDirectory", destinationDirectory);
         }

         if (!directoryInfo.Exists)
         {
            Console.WriteLine("Directory has been deleted or moved.");
         }
      }
   }
}
