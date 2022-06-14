using System.Text;

namespace DigitalBank
{
   public class Account
   {
      public ulong Number { get; }
      public string Owner { get; set; }
      public decimal Balance
      {
         get
         {
            return _balance;
         }
      }
      private static ulong _accountNumberSeed = 1000000000000000;
      private decimal _balance;
      public List<Transaction> _transactions;

      public Account(string owner, decimal initialBalance)
      {
         if (initialBalance < 500)
         {
            throw new ArgumentOutOfRangeException(nameof(initialBalance), "Min opening balance need to be 500 or more.");
         }
         this.Owner = owner;
         _balance = initialBalance;
         Number = _accountNumberSeed;
         _accountNumberSeed++;
         _transactions = new List<Transaction>(){
            new Transaction(initialBalance, DateTime.Now, "Opening balance.")
         };
      }

      public void Deposite(decimal amount, DateTime date, string note)
      {
         if (amount <= 0)
         {
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposite amount need to positive.");
         }
         _balance += amount;
         _transactions.Add(new Transaction(amount, date, note));
      }

      public void Withdraw(decimal amount, DateTime date, string note)
      {
         if (amount <= 0)
         {
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount need to positive.");
         }
         if (_balance - amount < 0)
         {
            throw new InvalidOperationException($"Insufficient funds for this withdrawal amount. Available balance is: {Balance}");
         }
         _balance -= amount;
         _transactions.Add(new Transaction(-amount, date, note));
      }

      public string GetTransactionHistory()
      {
         decimal balance = 0;
         var transactionHistory = new StringBuilder();
         transactionHistory.AppendLine("Date\t\tAmount\tBalance\tNote");
         foreach(var transaction in _transactions )
         {
            balance += transaction.Amount;
            transactionHistory.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Note}");
         }
         return transactionHistory.ToString();
      }
   }
}
