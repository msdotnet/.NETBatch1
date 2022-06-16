using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank
{
   public class Transaction
   {
      public Amount Amount;
      public DateTime Date { get; set; }
      public string? Note { get; set; }

      public Transaction(Amount amount, DateTime date, string note)
      {
         Amount = amount;
         Date = date;
         Note = note;
      }
      public static string GetTransactionHistory(List<Transaction> transactions)
      {
         decimal balance = 0;
         var transactionHistory = new StringBuilder();
         transactionHistory.AppendLine("Date\t\tAmount\tBalance\tNote");
         foreach (var transaction in transactions)
         {
            balance += transaction.Amount.Value;
            transactionHistory.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{balance}\t{transaction.Note}");
         }
         return transactionHistory.ToString();
      }
   }
}
