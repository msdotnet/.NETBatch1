
namespace DigitalBank.Tests.Core.Entities
{
   [TestClass]
   public class AccountTests
   {
      // Positive Test Case
      [TestMethod]
      public void Account_ValidOpeningBalance_ShouldSucceed()
      {
         // Arrange
         var owner = new Owner("Avishek", "Kumar");
         var openingBalance = new Amount { Value = 500, Currency = CurrencyType.INR };
         ulong expectedAccountNumber = 1000000000000000;

         // Act
         var account = new Account(owner, openingBalance);

         // Assert
         Assert.AreEqual<decimal>(openingBalance.Value, account.Balance);
         Assert.AreEqual("Initial amount.", account.Transactions.First().Note);
         Assert.AreEqual(expectedAccountNumber, account.Number);
      }

      // Negative Test Case
      [TestMethod]
      public void Account_InvalidOpeningBalance_ShouldThrowError()
      {
         // Arrange
         var owner = new Owner("Avishek", "Kumar");
         var openingBalance = new Amount { Value = 300, Currency = CurrencyType.INR };

         // Act & Assert
         Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Account(owner, openingBalance));
      }

      // Positive Test Case
      [TestMethod]
      public void Deposit_ValidAmount_ShouldSucceed()
      {
         // Arrange
         decimal depositAmount = 300m;
         decimal expectedBalance = 800;
         var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

         // Act
         var depositResult = account.Deposite(new Amount { Value = depositAmount, Currency = CurrencyType.INR }, DateTime.Now, "Depositing valid amount.");

         // Assert
         Assert.IsTrue(depositResult);
         Assert.AreEqual(expectedBalance, account.Balance);
      }

      // Negative Test Case
      [DataTestMethod]
      [DataRow(0d)]
      [DataRow(-1.5)]
      public void Deposit_AmountZeroOrLess_ShouldThrowError(double depositAmount)
      {
         // Arrange
         var account = new Account(new Owner("Avishek", "Kumar"), new Amount { Value = 500, Currency = CurrencyType.INR });

         // Act & Assert
         Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposite(new Amount { Value = (decimal)depositAmount, Currency = CurrencyType.INR }, DateTime.Now, "Depositing valid amount."));
      }
   }
}
