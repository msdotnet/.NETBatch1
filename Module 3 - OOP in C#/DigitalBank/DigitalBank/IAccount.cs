namespace DigitalBank
{
   public interface IAccount
   {
      decimal Balance { get; }
      ulong Number { get; }
      string Owner { get; set; }
      List<Transaction> Transactions { get; }

      void Deposite(Amount amount, DateTime date, string note);
      void Withdraw(Amount amount, DateTime date, string note);
   }
}