namespace DigitalBank
{
   public record struct Owner(string FirstName, string LastName)
   {
      public string FullName => $"{FirstName} {LastName}";
   }
}
