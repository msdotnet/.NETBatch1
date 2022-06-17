using System.Text;

namespace DigitalBank
{
   public class Transaction
   {
      public Amount Amount;
      public DateTime Date { get; set; }
      public string? Note { get; set; }
      public TransactionType Type { get; set; }
      public Transaction(Amount amount, DateTime date, string? note, TransactionType type)
      {
         Amount = amount;
         Date = date;
         Note = note;
         Type = type;
      }

      public static (string Description, string TransactionHistory) GetTransactionHistory(List<Transaction> transactions)
      {
         var description = $"Transaction history for {DateTime.Now.ToShortDateString()}";
         decimal balance = 0;
         var transactionHistory = new StringBuilder();
         transactionHistory.AppendLine("Date\t\tAmount\tBalance\tType\tNote");
         foreach (var transaction in transactions)
         {
            balance += transaction.Amount.Value;
            var note = transaction.Note?.ToUpper() ?? "No note.";
            transactionHistory.AppendLine($"{transaction.Date.ToShortDateString()}\t{transaction.Amount.Value}\t{balance}\t{transaction.Type.ToString()}\t{note.ToUpper()}");
         }
         return (description, transactionHistory.ToString());
      }
   }
}
