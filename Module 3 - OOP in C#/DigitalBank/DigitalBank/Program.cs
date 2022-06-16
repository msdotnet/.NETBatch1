// See https://aka.ms/new-console-template for more information
using DigitalBank;

Console.WriteLine("\n\tWelcome to QualMinds Digital Bank\n\n");

IAccount account = new Account("Avishek Kumar", new Amount {Value = 500, Currency = "INR" });
Console.WriteLine($"Account created for {account.Owner} with a initial balance of {account.Balance}");

account.Withdraw(new Amount { Value = 200, Currency = "INR" }, DateTime.Now, "Paying Rent.");
Console.WriteLine(account.Balance);

account.Deposite(new Amount { Value = 300, Currency = "INR" }, DateTime.Now, "Salary Received.");
Console.WriteLine(account.Balance);

account.Withdraw(new Amount { Value = 250, Currency = "INR" }, DateTime.Now, "Paid for mobile bill.");
Console.WriteLine(account.Balance);

Console.WriteLine($"\n{Transaction.GetTransactionHistory(account.Transactions)}");

#region Testing Invalid Operations

try
{
   account.Deposite(new Amount { Value = 0, Currency = "INR" }, DateTime.Now, "Salary Received.");
}
catch (ArgumentOutOfRangeException ex)
{
   Console.WriteLine(ex.Message);
}

try
{
   account.Withdraw(new Amount { Value = 1500, Currency = "INR" }, DateTime.Now, "Salary Received.");
}
catch (InvalidOperationException ex)
{
   Console.WriteLine(ex.Message);
}


try
{
   var invalidAccount = new Account("Avishek Kumar", new Amount { Value = -500, Currency = "INR" });
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