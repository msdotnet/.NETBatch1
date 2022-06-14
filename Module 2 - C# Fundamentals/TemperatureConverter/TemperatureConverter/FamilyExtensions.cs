namespace TemperatureConverter
{
   internal static class FamilyExtensions
   {
      public static string GetFullName(this Family family)
      {
         return $"{family.FirstName} {family.LastName}";
      }

   }
}
