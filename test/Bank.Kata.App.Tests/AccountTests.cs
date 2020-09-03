using System.Collections.Generic;
using Moq;
using Xunit;

namespace Bank.Kata.App.Tests
{
    [Trait("Category", "Unit")]
    public class AccountTests
    {
        private readonly Mock<ITransactionStore> transactionStore;
        private readonly Mock<IStatementPrinter> statementPrinter;
        private readonly Account account;

        public AccountTests()
        {
            transactionStore = new Mock<ITransactionStore>();
            statementPrinter = new Mock<IStatementPrinter>();
            account = new Account(transactionStore.Object, statementPrinter.Object);
        }

        [Fact(DisplayName = "Add a deposit amount")]
        public void Account_Deposit_AddTransaction()
        {
            var amount = new Amount(1000);

            account.Deposit(amount);

            transactionStore.Verify(d => d.AddDeposit(amount));
        }

        [Fact(DisplayName = "Add a withdrawal amount")]
        public void Account_Withdrawal_AddTransaction()
        {
            var amount = new Amount(500);

            account.Withdrawal(amount);

            transactionStore.Verify(w => w.AddWithdrawal(amount));
        }

        [Fact(DisplayName = "Prints a bank statement")]
        public void Account_Statement_PrintTransactions()
        {
            var transactions = new List<Transaction>() { new Transaction("10/01/2020", 1000) };

            transactionStore.Setup(t => t.All).Returns(transactions);

            account.PrintStatement();

            statementPrinter.Verify(p => p.Print(transactions));
        }
    }
}
