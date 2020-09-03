using System.Collections.Generic;
using Moq;
using NFluent;
using Xunit;

namespace Bank.Kata.App.Tests
{
    [Trait("Category", "Integration")]
    public class InMemoryTransactionStoreTests
    {
        private const string Today = "10/01/2020";

        private readonly Mock<IClock> clock;
        private readonly InMemoryTransactionStore transactionStore;

        public InMemoryTransactionStoreTests()
        {
            clock = new Mock<IClock>();
            clock.Setup(t => t.TodayAsString()).Returns("10/01/2020");
            transactionStore = new InMemoryTransactionStore(clock.Object);
        }

        [Fact(DisplayName = "Stores a deposit transaction")]
        public void InMemoryTransactionStore_Deposit_Store()
        {
            transactionStore.AddDeposit(new Amount(100));

            IReadOnlyList<Transaction> transactions = transactionStore.All;

            Check.That(transactions).ContainsExactly(Deposit(Today, 100));
        }

        [Fact(DisplayName = "Stores a withdrawal transaction")]
        public void InMemoryTransactionStore_Withdrawal_Store()
        {
            transactionStore.AddWithdrawal(new Amount(100));

            IReadOnlyList<Transaction> transactions = transactionStore.All;

            Check.That(transactions).ContainsExactly(Withdrawal(Today, -100));
        }

        private Transaction Deposit(string date, int amount) => new Transaction(date, amount);

        private Transaction Withdrawal(string date, int amount) => new Transaction(date, amount);
    }
}
