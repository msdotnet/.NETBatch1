// See https://aka.ms/new-console-template for more information
using ErrorHandling;

Console.WriteLine("Hello, World!");

var filePath = @"D:\Training\.NETBatch1\Module 3 - OOP in C#\ErrorHandling\ErrorHandling\TextDat.txt";
try
{
   Console.WriteLine(GetFileText(filePath));
}
catch (Exception ex)
{
   Console.WriteLine("Unexpected error occured while processing your request.");
   Console.WriteLine($"Error Details: {ex.ToString()}");
}

Console.WriteLine("Executed after file is read.");
string[] arrayData = { "A", "B", "C" };
try
{
   Console.WriteLine($"Find the value at position {2 + 1}: {GetArrayValueNestedException(arrayData)}");
}
catch (ArgumentOutOfRangeException ex)
{
   Console.WriteLine(ex.Message);
}


var list = new List<string> { "A", "B", "C" };

try
{
   Console.WriteLine($"Searched value in a list is: {FindValueInList(list, "D")}");
}
catch (NotFoundException ex)
{
   Console.WriteLine(ex.Message);
}

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
   catch (Exception ex)
   {
      // Some logs here
      throw;
   }
   finally
   {
      // Cleanup the unused resources. 
   }
}

static string GetArrayValue(string[] array, int index)
{
   //if (index > array.Length - 1 || index < 0)
   //{
   //   throw new ArgumentOutOfRangeException("Index passed is out of range", nameof(index));
   //}
   try
   {
      return array[index];
   }
   catch (IndexOutOfRangeException ex)
   {
      //logging
      throw new ArgumentException("Index passed was invalid.", nameof(index), innerException: ex);
   }
}
static string GetArrayValueNestedException(string[] array)
{
   try
   {
      return GetArrayValue(array, 3);
   }
   catch (ArgumentException ex)
   {
      Console.WriteLine(ex.Message);
      throw new ArgumentOutOfRangeException($"Index passed was out of the range. Valid range is: 0-{array.Length - 1}", innerException: ex);
   }
}
static string FindValueInList(List<string> list, string searchValue)
{
   var result = list.Where(l => l == searchValue).FirstOrDefault();
   if (result == null)
   {
      throw new NotFoundException($"Record you are searching for doesn't exist.", $"Additional Information here, list length: {list.Count}");
   }
   return result;
}
