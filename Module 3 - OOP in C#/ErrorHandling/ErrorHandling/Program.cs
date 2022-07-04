// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var filePath = @"D:\Training\.NETBatch1\Module 3 - OOP in C#\ErrorHandling\ErrorHandling\TextDat.txt";
try
{
   Console.WriteLine(GetFileText(filePath));
}
catch(Exception ex)
{
   Console.WriteLine("Unexpected error occured while processing your request.");
   Console.WriteLine($"Error Details: {ex.ToString()}");
}

Console.WriteLine("Executed after file is read.");

static string GetFileText(string filePath)
{
   try
   {
      return File.ReadAllText(filePath);
   }
   catch (DirectoryNotFoundException ex)
   {
      return $"The directory name supplied is mispelled or doesn't exist.\nMore details here: {ex.Message}";
   }
   catch (FileNotFoundException ex)
   {
      return $"The file name supplied is mispelled or doesn't exist.\nMore details here: {ex.Message}";
   }
   catch(Exception ex)
   {
      // Some logs here
      throw;
   }
   finally
   {
      // Cleanup the unused resources. 
   }
}