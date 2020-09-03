using System.Collections.Generic;

namespace Bank.Kata.App
{
    public interface IStatementPrinter
    {
        void Print(IEnumerable<Transaction> transactions);
    }
}
