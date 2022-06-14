// See https://aka.ms/new-console-template for more information
using DigitalBank;

Console.WriteLine("\n\tWelcome to QualMinds Digital Bank\n\n");

var account = new Account("Avishek Kumar", 500);
Console.WriteLine($"Account created for {account.Owner} with a initial balance of {account.Balance}");

account.Withdraw(200, DateTime.Now, "Paying Rent.");
Console.WriteLine(account.Balance);

account.Deposite(300, DateTime.Now, "Salary Received.");
Console.WriteLine(account.Balance);

account.Withdraw(150, DateTime.Now, "Paid for mobile bill.");
Console.WriteLine(account.Balance);

Console.WriteLine($"\n{account.GetTransactionHistory()}");


#region Testing Invalid Operations

try
{
   account.Deposite(0, DateTime.Now, "Salary Received.");
}
catch (ArgumentOutOfRangeException ex)
{
   Console.WriteLine(ex.Message);
}

try
{
   account.Withdraw(10000, DateTime.Now, "Salary Received.");
}
catch (InvalidOperationException ex)
{
   Console.WriteLine(ex.Message);
}


try
{
   var invalidAccount = new Account("Avishek Kumar", -500);
}
catch(ArgumentOutOfRangeException ex)
{
   Console.WriteLine(ex);
}
catch
{
   Console.WriteLine("Unhandled Exception");
}

#endregion