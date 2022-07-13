using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNDirectoryPlayground
{
   public class FilePlayground
   {
      static string directoryPath = @"D:\Training\.NETBatch1\Module 3 - OOP in C#\Files";
      static string fileName = "FirstFile.txt";
      public static void PlayWithFile()
      {
         var fullPath = Path.Combine(directoryPath, fileName);
         FileStream fileStream = null;
         try
         {
            if (Directory.Exists(directoryPath))
            {
               fileStream = File.Create(fullPath);
            }
            else
            {
               Console.WriteLine("Directory doesn't exist.");
            }

         }
         catch (IOException ex)
         {
            Console.WriteLine(ex.Message);
         }
         finally
         {
            fileStream?.Dispose();
            //fileStream.Close();
         }

         File.WriteAllText(fullPath, "Watermelon\n");

         var fruits = new List<string>() { "Apple", "Orange", "Banana" };

         //File.WriteAllLines(fullPath, fruits);

         File.AppendAllLines(fullPath, fruits);

         File.AppendAllText(fullPath, "Mango");

         //if (File.Exists(fullPath) /*&& !File.Exists(Path.Combine(directoryPath, "FirstFileCopy1.txt"))*/) 
         //{
         //   //File.Copy(fullPath, Path.Combine(directoryPath, "FirstFileCopy1.txt"), true);

         //   File.Move(fullPath, Path.Combine(directoryPath + "\\Moved", fileName));
         //}
         //File.Delete(Path.Combine(directoryPath, fileName));
      }
   }
}
