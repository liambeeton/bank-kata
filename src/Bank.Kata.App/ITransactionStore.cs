using System.Collections.Generic;

namespace Bank.Kata.App
{
    public interface ITransactionStore
    {
        IReadOnlyList<Transaction> All { get; }
        void AddDeposit(Amount amount);
        void AddWithdrawal(Amount amount);
    }
}