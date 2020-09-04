using System.Collections.Generic;

namespace Bank.Kata.App
{
    public class InMemoryTransactionStore : ITransactionStore
    {
        private readonly List<Transaction> transactions = new List<Transaction>();
        private readonly IClock clock;

        public InMemoryTransactionStore(IClock clock)
        {
            this.clock = clock;
        }

        public IReadOnlyList<Transaction> All => transactions.AsReadOnly();

        public void AddDeposit(Amount amount)
        {
            transactions.Add(new Transaction(clock.TodayAsString(), amount.Value));
        }

        public void AddWithdrawal(Amount amount)
        {
            transactions.Add(new Transaction(clock.TodayAsString(), -amount.Value));
        }
    }
}
