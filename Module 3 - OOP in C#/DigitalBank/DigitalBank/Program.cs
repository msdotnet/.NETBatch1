// See https://aka.ms/new-console-template for more information
using DigitalBank;

Console.WriteLine("\n\tWelcome to QualMinds Digital Bank\n\n");

IAccount account = new Account(new Owner("Avishek", "Kumar"), new Amount {Value = 500, Currency = CurrencyType.INR });
Console.WriteLine($"Account created for {account.Owner.FullName} with a initial balance of {account.Balance}");

account.Withdraw(new Amount { Value = 200, Currency = CurrencyType.INR }, DateTime.Now, "Paying Rent.");
Console.WriteLine(account.Balance);

account.Deposite(new Amount { Value = 300, Currency = CurrencyType.INR }, DateTime.Now, "Salary Received.");
Console.WriteLine(account.Balance);

account.Withdraw(new Amount { Value = 250, Currency = CurrencyType.INR }, DateTime.Now, null);
Console.WriteLine(account.Balance);

var transactionHistory = Transaction.GetTransactionHistory(account.Transactions);
Console.WriteLine($"\n{transactionHistory.Description}:\n{transactionHistory.TransactionHistory}");

#region Testing Invalid Operations

try
{
   account.Deposite(new Amount { Value = 0, Currency = CurrencyType.INR }, DateTime.Now, "Salary Received.");
}
catch (ArgumentOutOfRangeException ex)
{
   Console.WriteLine(ex.Message);
}

try
{
   account.Withdraw(new Amount { Value = 1500, Currency = CurrencyType.INR }, DateTime.Now, "Salary Received.");
}
catch (InvalidOperationException ex)
{
   Console.WriteLine(ex.Message);
}


try
{
   var invalidAccount = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = -500, Currency = CurrencyType.INR });
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